using Sdl.TellMe.ProviderApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capybara.EditorPlugin.SegmentSearcher.TellMeProvider
{
    public class SegmentSearcherFilesViewAction : AbstractTellMeAction
    {
        public SegmentSearcherFilesViewAction()
        {
            Name = "SegmentSearcher - Trados Settings";
        }

        public override string Category => $"{PluginResources.Plugin_Name} results";

        public override Icon Icon => PluginResources.SegmentSearcher_Settings;

        public override bool IsAvailable => SdlTradosStudio.Application.GetController<EditorController>().ActiveDocument != null;

        public override void Execute()
        {
            SdlTradosStudio.Application.GetController<EditorController>().Activate();
            SdlTradosStudio.Application.GetController<SegmentSearcherViewPartController>().Activate();
        }
    }
}
