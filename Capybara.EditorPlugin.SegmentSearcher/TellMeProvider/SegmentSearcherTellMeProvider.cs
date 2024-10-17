using Sdl.TellMe.ProviderApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Actions;

namespace Capybara.EditorPlugin.SegmentSearcher.TellMeProvider
{
    [TellMeProvider]
    public class SegmentSearcherTellMeProvider : ITellMeProvider
    {
        public string Name => "Segment Searcher";

        public AbstractTellMeAction[] ProviderActions => new AbstractTellMeAction[]
        {
            new SegmentSearcherContactAction()
            {
                Keywords = new[]
                {
                    "segmentsearcher", "segment searcher", "segmentsearcher trados",
                    "segment searcher trados", "segmentsearcher documentation",
                    "segment searcher documentation"
                }
            },

            new SegmentSeracherCommunitySupportAction()
            {
                Keywords = new[]
                {
                    "segmentsearcher", "segment searcher", "segmentsearcher trados",
                    "segment searcher trados", "segmentsearcher support", "segment searcher support",
                    "segment searcher community", "segmentsearcher community", "segment searcher forum",
                    "segmentsearcher forum"
                }
            },

            new SegmentSearcherSourceCodeAction()
            {
                Keywords = new[]
                {
                    "segmentsearcher", "segment searcher", "segmentsearcher trados", "segment searcher trados",
                    "segmentsearcher code", "segment searcher code", "segment searcher source", "segmentsearcher source",
                }
            },

            new SegmentSearcherFilesViewAction()
            {
                Keywords = new[]
                {
                    "segmentsearcher", "segment searcher", "segmentsearcher trados", "segment searcher trados",
                    "segmentsearcher settings", "segment searcher settings"
                }
            }
        };
    }
}
