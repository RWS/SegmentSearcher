using Sdl.TellMe.ProviderApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capybara.EditorPlugin.SegmentSearcher.TellMeProvider
{
    public class SegmentSearcherSourceCodeAction : AbstractTellMeAction
    {
        public SegmentSearcherSourceCodeAction()
        {
            Name = "SegmentSearcher - Trados - Trados Source Code";
        }

        public override string Category => $"{PluginResources.Plugin_Name} results";

        public override Icon Icon => PluginResources.SegmentSearcher_SourceCode;

        public override bool IsAvailable => true;

        public override void Execute()
        {
            Process.Start("https://github.com/RWS/SegmentSearcher");
        }
    }
}
