using System;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Capybara.EditorPlugin.SegmentSearcher_2017
{
    [ViewPart(
        Id = "SegmentSearcherViewPart",
        Name = "Plugin_Name",
        Description = "Plugin_Description",
        Icon = "SegmentSearcher_Icon"
    )]
    [ViewPartLayout(typeof(EditorController), Dock = DockType.Bottom)]
    class SegmentSearcherViewPartController : AbstractViewPartController
    {
        protected override System.Windows.Forms.Control GetContentControl()
        {
            return Control.Value;
        }

        protected override void Initialize()
        {
        }

        public void Search(string text)
        {
            Control.Value.SearchByContextMenuAction(text);
        }

        private static readonly Lazy<SegmentSearcherViewPartControl> Control = new Lazy<SegmentSearcherViewPartControl>(() => new SegmentSearcherViewPartControl());   
    }
}
