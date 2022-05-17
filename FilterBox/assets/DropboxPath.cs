using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tsuku;
using Tsuku.Extensions;

namespace FilterBox.assets
{
    public static class Dropbox
    {
        private static string path = "";
        public static void locateDropbox()
        {
            var infoPath = @"Dropbox\info.json";
            var jsonPath = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), infoPath);
            if (!File.Exists(jsonPath)) jsonPath = Path.Combine(Environment.GetEnvironmentVariable("AppData"), infoPath);
            if (!File.Exists(jsonPath)) throw new Exception("Dropbox could not be found!");

            path = File.ReadAllText(jsonPath).Split('\"')[5].Replace(@"\\", @"\");
        }

        public static string getFolder()
        {
            return path;
        }

        public static void Ignore(string path, bool ignore = true)
        {
            FileAttributes attr = File.GetAttributes(path);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                var folder = new DirectoryInfo(path);
                try
                {
                    if (ignore)
                        folder.SetAttribute("com.dropbox.ignored", "1");
                    else
                        folder.DeleteAttribute("com.dropbox.ignored");
                }
                catch (IOException)
                {
                    // Failed
                }
            } else
            {
                var file = new FileInfo(path);
                try
                {
                    if (ignore)
                        file.SetAttribute("com.dropbox.ignored", "1");
                    else
                        file.DeleteAttribute("com.dropbox.ignored");
                }
                catch (IOException)
                {
                    // Failed
                }
            }
        }
    }
}
