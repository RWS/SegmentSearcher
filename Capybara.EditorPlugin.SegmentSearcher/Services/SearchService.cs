using Capybara.EditorPlugin.SegmentSearcher.FileManagement;
using Sdl.Core.Globalization;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Capybara.EditorPlugin.SegmentSearcher.Services
{
    public class SearchService : ISearchService
    {
        private readonly IFileManager _fileManager = new FileManager();

        public string Search(SearchSettings search, EditorController controller)
        {
            var xhtml = ExecuteSearch(search, controller);
            return SaveXhtml(xhtml);
        }

        private XDocument ExecuteSearch(SearchSettings search, EditorController controller)
        {
            IEnumerable<IStudioDocument> searchDocuments = search.OnlyInActiveDocument
                ? new List<IStudioDocument> { controller.ActiveDocument }
                : controller.GetDocuments();
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

        private string SaveXhtml(XDocument xhtml)
        {
            // Save the XHTML Content
            var xhtmlPath = _fileManager.SaveXhtml(xhtml);

            // Save required resources
            _fileManager.SaveResource("base.css", PluginResources.base_css);
            _fileManager.SaveResource("jquery.js", PluginResources.jquery);
            _fileManager.SaveResource("main.js", PluginResources.main_js);

            return xhtmlPath;
        }
    }
}
