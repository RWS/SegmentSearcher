using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capybara.EditorPlugin.SegmentSearcher.Services
{
    public interface ISearchService
    {
        string Search(SearchSettings searchSettings, EditorController controller);
    }
}
