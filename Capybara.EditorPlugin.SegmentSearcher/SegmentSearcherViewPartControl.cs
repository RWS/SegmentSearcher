using System;
using System.Linq;
using System.Security.Permissions;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Capybara.EditorPlugin.SegmentSearcher.FileManagement;
using Capybara.EditorPlugin.SegmentSearcher.Services;

namespace Capybara.EditorPlugin.SegmentSearcher
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class SegmentSearcherViewPartControl : UserControl, IUIControl
    {
        private const int FindWhatMaxHistory = 30;
        private readonly ISearchService _searchService;
        private IStudioDocument _currentDoc;
        private ISegmentPair _currentSegmentPair;

        public SegmentSearcherViewPartControl()
        {
            InitializeComponent();
            _searchService = new SearchService();
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
            var path = _searchService.Search(search, GetEditorController());
            searchResultsWebBrowser.Url = new Uri(path);
        }

        public void SearchByContextMenuAction(string text)
        {
            findWhatComboBox.Text = text;
            searchButton_Click(null, null);
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
