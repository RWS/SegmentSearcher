using System.Text.RegularExpressions;

namespace Capybara.EditorPlugin.SegmentSearcher_2017
{
    public class SearchSettings
    {
        public string FindWhat { get; set; }
        public bool InSource { get; set; }
        public bool InTarget { get; set; }
        public bool UseRegex { get; set; }
        public bool MatchCase { get; set; }
        public bool MatchWholeWord { get; set; }
        public bool IncludeTags { get; set; }
        public bool OnlyInActiveDocument { get; set; }
        public RegexOptions RegexOptions { get; set; }
    }
}
