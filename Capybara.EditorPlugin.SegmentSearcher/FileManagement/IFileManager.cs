using System.Xml.Linq;

namespace Capybara.EditorPlugin.SegmentSearcher.FileManagement
{
    public interface IFileManager
    {
        string SaveXhtml(XDocument xhtml);

        void SaveResource(string fileName, string content);
    }
}
