using System.Diagnostics;

namespace FilterBox.assets
{
    public static class Autostart
    {
        public static string ShortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\FilterBox.lnk";
        public static void toggleAutostart()
        {

            if (isAutostarting())
                File.Delete(ShortcutPath);
            else
                createAppStartupShortcut();
        }

        public static bool isAutostarting()
        {
            if (File.Exists(ShortcutPath))
                return true;
            else
                return false;
        }

        private static void createAppStartupShortcut()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string app = Process.GetCurrentProcess().MainModule.FileName;

            IWshRuntimeLibrary.WshShell wsh = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(ShortcutPath) as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = "--silent";
            shortcut.TargetPath = app;
            // not sure about what this is for
            shortcut.WindowStyle = 1;
            shortcut.Description = "FilterBox - Dropbox file filtering";
            shortcut.WorkingDirectory = directory;
            shortcut.IconLocation = AppDomain.CurrentDomain.BaseDirectory+"/assets/FilterBox.ico";
            shortcut.Save();
        }
    }
}
