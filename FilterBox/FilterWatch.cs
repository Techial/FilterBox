using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FilterBox.assets;
using System.Text.RegularExpressions;

namespace FilterBox
{
    public class FilterWatch
    {
        private List<FileSystemWatcher> Watchers = new List<FileSystemWatcher>();
        private string lastChangeddPath = ""; // Prevent spam
        private string lastCreatedPath  = ""; // Prevent spam
        private string lastDeletedPath  = ""; // Prevent spam
        private string lastRenamedPath  = ""; // Prevent spam

        private class ScanResult
        {
            public string[] files;
            public string[] folders;

            public ScanResult(string[] files, string[] folders)
            {
                this.files = files;
                this.folders = folders;
            }

        }

        private static void FilterSearch(ref List<ScanResult> scanResults)
        {
            List<ScanResult> tempResult = new List<ScanResult>();

            string[] emptyArr = new string[0];

            foreach (Filter filter in Settings.Configuration.Filters)
            {
                Regex filterRegex = new Regex(filter.Name);
                for (int i = 0; i < scanResults.Count; i++)
                {
                    ScanResult result = scanResults[i];

                    if (filter.Type.Contains("file")) {
                        List<string> tFiles = new List<string>();
                        foreach (string file in result.files)
                        {
                            if(filterRegex.IsMatch(Path.GetFileName(file)))
                                tFiles.Add(file);
                        }
                        scanResults[i].files = tFiles.ToArray();
                    } else
                    {
                        scanResults[i].files = emptyArr;
                    }


                    if (filter.Type.Contains("folder"))
                    {
                        List<string> tFolders = new List<string>();
                        foreach (string folder in result.folders)
                        {
                            string FolderName = new DirectoryInfo(folder).Name;
                            if (filterRegex.IsMatch(FolderName))
                                tFolders.Add(folder);
                        }
                        scanResults[i].folders = tFolders.ToArray();
                    } else
                    {
                        scanResults[i].folders = emptyArr;
                    }

                    if(scanResults[i].files.Count() > 0 || scanResults[i].folders.Count() > 0)
                        tempResult.Add(scanResults[i]);
                }
            }

            scanResults.Clear();
            scanResults.AddRange(tempResult);
        }

        private static List<ScanResult> SearchDirectory(string path)
        {
            List<ScanResult> scanResults = new List<ScanResult>();

            // First add directory & files
            ScanResult currDir = new ScanResult(
                        Directory.GetFiles(path),
                        Directory.GetDirectories(path)
                    );
            scanResults.Add(currDir);

            bool folderInFilter = false;

            foreach (Filter filter in Settings.Configuration.Filters)
            {
                if (!filter.Type.Contains("folder"))
                    continue;

                Regex filterRegex = new Regex(filter.Name);
                string FolderName = new DirectoryInfo(path).Name;
                if (filterRegex.IsMatch(FolderName))
                    folderInFilter = true;
            }

            if (!folderInFilter)
            {
                // Now find all recursive files & directories
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    List<ScanResult> result = SearchDirectory(directory);
                    scanResults.AddRange(result);
                }
            }

            return scanResults;
        }

        public static void ManualScan()
        {
            // Configuration.filters
            List<ScanResult> scanResults = SearchDirectory(Dropbox.getFolder());
            FilterWatch.FilterSearch(ref scanResults);

            foreach(ScanResult result in scanResults)
            {
                foreach(string file in result.files)
                {
                    //Dropbox.Ignore(file);
                }

                foreach (string folder in result.folders)
                {
                    //Dropbox.Ignore(folder);
                }
            }
        }

        public void AddFilterWatcher(Filter filter, string folder)
        {
            if (folder == null)
                return;

            string[] filterTypes = filter.Type.Split(' ');

            FileSystemWatcher watcher = new FileSystemWatcher(folder);

            if (filterTypes.Contains("folder"))
            {
                watcher.NotifyFilter = NotifyFilters.DirectoryName;
            }

            if (filterTypes.Contains("file"))
            {
                watcher.NotifyFilter |= NotifyFilters.FileName;
            }

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;

            watcher.Filter = filter.Name;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Watchers.Add(watcher);
        }

        public bool StartWatching(string folder)
        {
            if (folder == null)
                return false;

            foreach (Filter filter in Settings.Configuration.Filters)
            {
                AddFilterWatcher(filter, folder);
            }

            return true;
        }

        public void StopWatching()
        {
            foreach(FileSystemWatcher watcher in Watchers)
            {
                watcher.Changed -= OnChanged;
                watcher.Created -= OnCreated;
                watcher.Deleted -= OnDeleted;
                watcher.Renamed -= OnRenamed;
                watcher.Dispose();
            }
        }

        public void StopInactiveFilters()
        {
            foreach (FileSystemWatcher watcher in Watchers)
            {
                bool isActive = false;

                foreach (Filter filter in Settings.Configuration.Filters)
                {
                    if (watcher.Filter == filter.Name)
                    {
                        isActive = true;
                        break;
                    }
                }

                if (!isActive)
                {
                    watcher.Changed -= OnChanged;
                    watcher.Created -= OnCreated;
                    watcher.Deleted -= OnDeleted;
                    watcher.Renamed -= OnRenamed;
                    watcher.Dispose();
                }
            }
        }

        private void OnChanged(object sneder, FileSystemEventArgs e)
        {
            if (lastChangeddPath == e.FullPath)
                return;

            lastChangeddPath = e.FullPath;
            Dropbox.Ignore(e.FullPath);
        }

        private void OnCreated(object sneder, FileSystemEventArgs e)
        {
            if (lastCreatedPath == e.FullPath)
                return;

            lastCreatedPath = e.FullPath;
            Dropbox.Ignore(e.FullPath);
        }

        private void OnDeleted(object sneder, FileSystemEventArgs e)
        {
            if (lastDeletedPath == e.FullPath)
                return;

            lastDeletedPath = e.FullPath;
            // Do nothing for now
        }

        private void OnRenamed(object sneder, FileSystemEventArgs e)
        {
            if (lastRenamedPath == e.FullPath)
                return;

            lastRenamedPath = e.FullPath;
            Dropbox.Ignore(e.FullPath);
        }
    }
}
