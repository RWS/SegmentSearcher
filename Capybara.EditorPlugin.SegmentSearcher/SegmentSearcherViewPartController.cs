using System;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Capybara.EditorPlugin.SegmentSearcher
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
        protected override IUIControl GetContentControl()
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
