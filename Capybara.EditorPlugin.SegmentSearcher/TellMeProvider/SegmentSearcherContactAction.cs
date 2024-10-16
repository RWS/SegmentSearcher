using Sdl.TellMe.ProviderApi;
using System.Diagnostics;
using System.Drawing;

namespace Capybara.EditorPlugin.SegmentSearcher.TellMeProvider
{
    public class SegmentSearcherContactAction : AbstractTellMeAction
    {
        public SegmentSearcherContactAction()
        {
            Name = "SegmentSearcher - Trados Documentation";
        }

        public override bool IsAvailable => true;

        public override string Category => $"{PluginResources.Plugin_Name} results";

        public override Icon Icon => PluginResources.SegmentSearcher_Documentation;

        public override void Execute()
        {
            Process.Start("https://appstore.rws.com/Plugin/279?tab=documentation");
        }
    }
}
