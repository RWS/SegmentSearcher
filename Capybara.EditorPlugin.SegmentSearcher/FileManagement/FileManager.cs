using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Capybara.EditorPlugin.SegmentSearcher.FileManagement
{
    public class FileManager : IFileManager
    {
        private readonly string _basePath;

        public FileManager()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            _basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), assemblyName);   

            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public string SaveXhtml(XDocument xhtml)
        {
            var filePath = Path.Combine(_basePath, "templ.html");
            xhtml.Save(filePath, SaveOptions.None);
            return filePath;
        }

        public void SaveResource(string fileName, string content)
        {
            var filePath = Path.Combine(_basePath, fileName);
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }
    }
}
