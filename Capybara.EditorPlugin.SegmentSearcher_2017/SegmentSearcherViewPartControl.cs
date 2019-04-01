using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Sdl.Core.Globalization;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Capybara.EditorPlugin.SegmentSearcher_2017
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class SegmentSearcherViewPartControl : UserControl
    {
        private const int FindWhatMaxHistory = 30;
        private Document _currentDoc;
        private ISegmentPair _currentSegmentPair;
        

        public SegmentSearcherViewPartControl()
        {
            InitializeComponent();
            var toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(searchButton, "Execute search.");
            toolTip.SetToolTip(returnButton, "Return to the segment where you executed search.");
            _currentDoc = null;
            _currentSegmentPair = null;   
            searchResultsWebBrowser.ObjectForScripting = this;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                searchButton_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private EditorController GetEditorController()
        {
            return SdlTradosStudio.Application.GetController<EditorController>();
        }

        private string SaveXhtml(XDocument xhtml)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            var name = executingAssembly.GetName().Name;
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), name);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // copy css
            var cssPath = Path.Combine(path, "base.css");
            File.WriteAllText(cssPath, PluginResources.base_css, Encoding.UTF8);

            // copy jquery
            var jqueryPath = Path.Combine(path, "jquery.js");
            File.WriteAllText(jqueryPath, PluginResources.jquery, Encoding.UTF8);

            // copy js
            var mainJsPath = Path.Combine(path, "main.js");
            File.WriteAllText(mainJsPath, PluginResources.main_js, Encoding.UTF8);

            // save xhtml
            var xhtmlPath = Path.Combine(path, "temp" + ".html");
            xhtml.Save(xhtmlPath, SaveOptions.None);

            return xhtmlPath;
        }

        private void AddFindWhatHisotry()
        {
            var text = findWhatComboBox.Text;
            if (!string.IsNullOrEmpty(text) && findWhatComboBox.FindStringExact(text) == -1)
            {
                findWhatComboBox.Items.Insert(0, text);
            }
            if (findWhatComboBox.Items.Count > FindWhatMaxHistory)
            {
                findWhatComboBox.Items.RemoveAt(FindWhatMaxHistory);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var editorController = GetEditorController();
            editorController.Activate();
            if (editorController.ActiveDocument == null || 
                string.IsNullOrEmpty(findWhatComboBox.Text) ||
                (!inSourceCheckBox.Checked && !inTargetCheckBox.Checked))
            {
                return;
            }

            if (useRegexCheckBox.Checked)
            {
                try
                {
                    Regex.IsMatch("DummyText", findWhatComboBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }


            AddFindWhatHisotry();
            _currentDoc = editorController.ActiveDocument;
            _currentSegmentPair = _currentDoc.GetActiveSegmentPair();
            
            var search = GetSearchSettings();
            var xhtml = ExecuteSearch(search);
            var path = SaveXhtml(xhtml);

            searchResultsWebBrowser.Url = new Uri(path);
        }

        public void SearchByContextMenuAction(string text)
        {
            findWhatComboBox.Text = text;
            searchButton_Click(null, null);
        }

        private XDocument ExecuteSearch(SearchSettings search)
        {
            var editorController = GetEditorController();
            IEnumerable<Document> searchDocuments = search.OnlyInActiveDocument
                ? new List<Document> { editorController.ActiveDocument }
                : editorController.GetDocuments();
            var xhtml = XDocument.Parse(PluginResources.base_html);
            var resultsElem = xhtml.Descendants(Xhtml.table).First(x => x.Attribute("id").Value == "results");
            var isEven = false;
            var files = new Dictionary<string, string>();
            foreach (var doc in searchDocuments)
            {
                foreach (var pair in doc.SegmentPairs)
                {
                    var sourceText = pair.Source.ToString();
                    var targetText = pair.Target.ToString();
                    if (!search.IncludeTags)
                    {
                        sourceText =
                            pair.Source.AllSubItems.OfType<IText>()
                                .Aggregate(new StringBuilder(), (builder, text) => builder.Append(text.Properties.Text)).ToString();
                        targetText =
                            pair.Target.AllSubItems.OfType<IText>()
                                .Aggregate(new StringBuilder(), (builder, text) => builder.Append(text.Properties.Text)).ToString();
                    }
                    sourceText = sourceText.Replace("\r\n", "\n").Replace("\r", "\n");
                    targetText = targetText.Replace("\r\n", "\n").Replace("\r", "\n");

                    MatchCollection srcMatches = null;
                    MatchCollection trgMatches = null;
                    if (search.InSource)
                    {
                        srcMatches = Regex.Matches(sourceText, search.FindWhat, search.RegexOptions);
                    }
                    if (search.InTarget)
                    {
                        trgMatches = Regex.Matches(targetText, search.FindWhat, search.RegexOptions);
                    }
                    if ((srcMatches != null && srcMatches.Count > 0) || (trgMatches != null && trgMatches.Count > 0))
                    {
                        var projectFile = pair.GetProjectFile();
                        var fileId = projectFile.Id.ToString();
                        var fileName = projectFile.Name;
                        if (!files.ContainsKey(fileId))
                        {
                            files.Add(fileId, fileName);
                        }
                        
                        isEven = !isEven;
                        var entryElem = GetEntryXhtml(
                            sourceText,
                            targetText,
                            pair.Properties.Id.Id,
                            fileId,
                            fileName,
                            pair.Properties.ConfirmationLevel,
                            pair.Properties.IsLocked,
                            srcMatches,
                            trgMatches,
                            isEven);
                        resultsElem.Add(entryElem);
                    }
                }
            }

            // Add file filter elements
            var selectElem = xhtml.Descendants(Xhtml.select).First(x => x.Attribute("name").Value == "file-filter");
            selectElem.Add(
                new XElement(Xhtml.option, new XAttribute("value", "#ALL#"), "ALL"), 
                files.Select(f => new XElement(Xhtml.option, new XAttribute("value", f.Key), f.Value)));

            var entryCount = resultsElem.Descendants(Xhtml.tbody).Count();
            xhtml.Descendants(Xhtml.span)
                .First(x => x.Attribute("id").Value == "filtered-count").SetValue(entryCount);
            xhtml.Descendants(Xhtml.span)
                .First(x => x.Attribute("id").Value == "all-count").SetValue(entryCount);

            return xhtml;
        }

        private XElement GetEntryXhtml(string sourceText, string targetText, 
            string segmentId, string fileId, string fileName, 
            ConfirmationLevel confLevel, bool isLocked,
            MatchCollection sourceMatches, MatchCollection targetMatches, bool isEven)
        {
            var tbodyElem = new XElement(Xhtml.tbody, 
                new XAttribute("class", isEven ? "entry-even" : "entry-odd"));
            
            var firstTrElem = new XElement(Xhtml.tr);
            // File id
            firstTrElem.Add(new XElement(Xhtml.td, new XAttribute("class", "file-id"), fileId));
            // Segmend Id, Confirmation level, Locked status
            firstTrElem.Add(
                new XElement(Xhtml.td,
                    new XAttribute("class", "seg-info"),
                    new XElement(Xhtml.a,
                        new XAttribute("href", "#"),
                        new XAttribute("onclick", string.Format("window.external.ActivateSegment('{0}', '{1}'); return false;", fileId, segmentId)),
                        new XText(segmentId))));
            firstTrElem.Add(
                new XElement(Xhtml.td,
                    new XAttribute("class", "seg-info"),
                    confLevel.ToString()));
            firstTrElem.Add(
                new XElement(Xhtml.td,
                    new XAttribute("class", "seg-info"),
                    isLocked ? "Yes" : "No"));
            // File name
            firstTrElem.Add(new XElement(Xhtml.td, fileName));
                             
            tbodyElem.Add(firstTrElem);

            var secondTrElem = new XElement(Xhtml.tr);
            // Source segment
            var sourceTdElem = GetSegmentXhtml(sourceText, sourceMatches);
            sourceTdElem.Add(new XAttribute("colspan", "3"));
            secondTrElem.Add(sourceTdElem);
            
            // Target segment
            var targetTdElem = GetSegmentXhtml(targetText, targetMatches);
            targetTdElem.Add(new XAttribute("colspan", "1"));
            secondTrElem.Add(targetTdElem);

            tbodyElem.Add(secondTrElem);

            return tbodyElem;
        }

        private XElement GetSegmentXhtml(string segmentText, MatchCollection matches)
        {
            if (matches == null || matches.Count == 0 || string.IsNullOrEmpty(segmentText))
            {
                return new XElement(Xhtml.td, GetSegmentFragment(segmentText));
            }
            var tdElem = new XElement(Xhtml.td, new XText(string.Empty));
            var idx = 0;
            foreach (Match match in matches)
            {
                if (match.Index > idx)
                {
                    tdElem.Add(GetSegmentFragment(segmentText.Substring(idx, match.Index - idx)));
                }
                tdElem.Add(new XElement(Xhtml.span, new XAttribute("class", "matched"),
                    GetSegmentFragment(segmentText.Substring(match.Index, match.Length))));
                idx = tdElem.Value.Length + tdElem.Descendants().Count(x => x.Name == Xhtml.br);
            }
            if (idx < segmentText.Length)
            {
                tdElem.Add(GetSegmentFragment(segmentText.Substring(idx)));
            }
            return tdElem;
        }

        private IEnumerable<XNode> GetSegmentFragment(string fragmentText)
        {
            return fragmentText.Select<char, XNode>(x =>
            {
                if (x == '\n')
                {
                    return new XElement(Xhtml.br);
                }
                return new XText(x.ToString(CultureInfo.InvariantCulture));
            });
        }

        private SearchSettings GetSearchSettings()
        {
            var search = new SearchSettings
            {
                FindWhat = findWhatComboBox.Text,
                InSource = inSourceCheckBox.Checked,
                InTarget = inTargetCheckBox.Checked,
                UseRegex = useRegexCheckBox.Checked,
                MatchCase = matchCaseCheckBox.Checked,
                MatchWholeWord = matchWholeWordCheckBox.Checked,
                IncludeTags = includeTagsCheckBox.Checked,
                OnlyInActiveDocument = onlyInActiveDocCheckBox.Checked
            };
            search.FindWhat = search.UseRegex
                ? search.FindWhat
                : Regex.Escape(search.FindWhat);
            search.FindWhat = search.MatchWholeWord
                ? @"\b" + search.FindWhat + @"\b"
                : search.FindWhat;
            search.RegexOptions = search.MatchCase 
                ? RegexOptions.None :          
                RegexOptions.IgnoreCase;
            return search;
        }

        public void ActivateSegment(string fileId, string segNumber)
        {
            var editorController = GetEditorController();
            var targetDoc = editorController.GetDocuments().FirstOrDefault(doc => doc.Files.Any(f => f.Id.ToString() == fileId));
            
            if (targetDoc != null)
            {
                editorController.Activate(targetDoc);
                var projectFile = targetDoc.Files.First(f => f.Id.ToString() == fileId);
                targetDoc.SetActiveSegmentPair(projectFile, segNumber, true);
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            if (_currentDoc != null && _currentSegmentPair != null)
            {
                var editorController = GetEditorController();
                editorController.Activate(_currentDoc);
                var projectFile = _currentSegmentPair.GetProjectFile();
                _currentDoc.SetActiveSegmentPair(projectFile, _currentSegmentPair.Properties.Id.Id, true);
            }
        }
    }
}
