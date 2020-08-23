using System.Windows.Forms;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace Capybara.EditorPlugin.SegmentSearcher
{
    [Action("SegmentSearcherAction", typeof(EditorController), Name = "SegmentSearcherAction_Name", Description = "SegmentSearcherAction_Description", Icon = "SegmentSearcher_Icon")]
    [ActionLayout(typeof(TranslationStudioDefaultContextMenus.EditorDocumentContextMenuLocation), 1, DisplayType.Large)]
    [Shortcut(Keys.Alt | Keys.F10)]
    public class SegmentSearcherAction : AbstractViewControllerAction<EditorController>
    {
        public override void Initialize()
        {
        }

        protected override void Execute()
        {
            var editorController = SdlTradosStudio.Application.GetController<EditorController>();
            var segmentSearcherViewPartController =
                SdlTradosStudio.Application.GetController<SegmentSearcherViewPartController>();

            var doc = editorController.ActiveDocument;
            if (doc == null)
            {
                return;
            }
            var text = doc.FocusedDocumentContent == FocusedDocumentContent.Source
                ? doc.Selection.Source.ToString()
                : doc.Selection.Target.ToString();
            if (!string.IsNullOrEmpty(text))
            {
                segmentSearcherViewPartController.Search(text);
                segmentSearcherViewPartController.Show();
            }
        }
    }
}
