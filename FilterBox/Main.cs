using FilterBox.assets;
using GUI;

namespace FilterBox
{
    public partial class Main : Form
    {
        public FilterWatch watcher;
        private FormWindowState SavedWindowState = FormWindowState.Normal;
        private bool startHidden = false;

        public Main(string[] args)
        {
            InitializeComponent();

            if (args.Length > 0)
            {
                if (args[0] == "--silent")
                    startHidden = true;
            }

            Dropbox.locateDropbox();
            string path = Dropbox.getFolder();

            // Load settings
            Settings.LoadSettings();

            // Preload app .ico
            Icon appIco = new Icon("./assets/FilterBox.ico");

            // Add our .ico to this Main form
            this.Icon = appIco;

            // Add our application to the system tray
            appIcon.Visible = true;
            appIcon.Icon = appIco;

            // Add a menu for our appIcon
            createNewContextMenu();

            // Initialize columnMapping for ListViewEx
            var columnMapping = new List<(string ColumnName, Func<Filter, object> ValueLookup, Func<Filter, string> DisplayStringLookup)>()
            {
                ("Name", filter => filter.Name, filter => filter.Name),
                ("Type", filter => filter.Type, filter => filter.Type),
            };

            filterList = new ListViewEx<Filter>(columnMapping)
            {
                FullRowSelect = true,
                View = View.Details,
            };

            filterList.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right);
            filterList.Location = new Point(12, 29);
            filterList.Name = "filterList";
            filterList.Size = new Size(548, 228);
            filterList.TabIndex = 10;

            Controls.Add(filterList);

            // Display filters in listViewEx - filterList
            filterList.AddRange(Settings.Configuration.Filters.ToArray()); // This creates the columns if not already exists
            filterList.Columns[0].Width = (filterList.Width*8)/10;

            watcher = new FilterWatch();
            watcher.StartWatching(path);
        }

        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem StartupLaunch;

        private void createNewContextMenu()
        {
            contextMenuStrip = new ContextMenuStrip();

            StartupLaunch = new ToolStripMenuItem("Launch on Startup", null, appIcon_onLOSClick);
            StartupLaunch.Checked = Autostart.isAutostarting();

            contextMenuStrip.Items.Add("Show", null, appIcon_onShowClick);
            contextMenuStrip.Items.Add(StartupLaunch);
            contextMenuStrip.Items.Add("Exit", null, appIcon_onExitClick);

            appIcon.ContextMenuStrip = contextMenuStrip;
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            FilterWatch.ManualScan();
        }

        private void addFilter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(addFilterInput.Text) || (!addFilterTypeFolder.Checked && !addFilterTypeFile.Checked))
                return;

            // Create a new filter
            Filter filter = new Filter();

            // Set filter name
            filter.Name = addFilterInput.Text;

            // Join all types in a string separated by spaces
            List<string> types = new List<string>();
            if (addFilterTypeFolder.Checked)
                types.Add("folder");
            if (addFilterTypeFile.Checked)
                types.Add("file");
            filter.Type = String.Join(" ", types);

            // Add filter to settings
            Settings.Configuration.Filters.Add(filter);

            // Save new settings
            Settings.SaveSettings();

            // Add filter to ListViewEx
            filterList.Add(filter);

            // Load new watcher
            watcher.AddFilterWatcher(filter, Dropbox.getFolder());
        }

        private void removeFilter_Click(object sender, EventArgs e)
        {
            if (filterList.SelectedIndices.Count <= 0)
                return;

            ListView.SelectedIndexCollection filterIDs = filterList.SelectedIndices;
            foreach(int filterID in filterIDs)
            {
                Filter filter = Settings.Configuration.Filters.ElementAt(filterID);
                Settings.Configuration.Filters.RemoveAt(filterID);
                filterList.Remove(filter);
            }

            // Save new settings
            Settings.SaveSettings();

            // Iterate through all filters and watchers
            watcher.StopInactiveFilters();
        }

        private void MainResized(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            } else
            {
                // Save our last window state
                SavedWindowState = WindowState;
            }
        }

        private void appIcon_onShowClick(object? sender, EventArgs e)
        {
            if (this.Visible && this.ShowInTaskbar)
                return;

            // Make sure all of the visible parameters are set to true
            this.Show();
            this.Visible = true;
            this.WindowState = SavedWindowState;
            this.ShowInTaskbar = true;
        }

        private void appIcon_onLOSClick(object? sender, EventArgs e)
        {
            Autostart.toggleAutostart();
            StartupLaunch.Checked = Autostart.isAutostarting();
        }

        private void appIcon_onExitClick(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void onMainLoaded(object sender, EventArgs e)
        {
            if(startHidden)
            {
                startHidden = false;
                this.WindowState = FormWindowState.Minimized;
                SavedWindowState = FormWindowState.Normal;
                this.ShowInTaskbar = false;
                this.Visible = false;
            }
        }
    }
}