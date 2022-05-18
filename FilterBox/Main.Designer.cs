using GUI;

namespace FilterBox
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.appIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.scanButton = new System.Windows.Forms.Button();
            this.filterLabel = new System.Windows.Forms.Label();
            this.addFilter = new System.Windows.Forms.Button();
            this.addFilterInput = new System.Windows.Forms.TextBox();
            this.removeFilter = new System.Windows.Forms.Button();
            this.addFilterTypeFolder = new System.Windows.Forms.CheckBox();
            this.addFilterTypeFile = new System.Windows.Forms.CheckBox();
            this.addFilterTypeLabel = new System.Windows.Forms.Label();
            this.addFilterInputLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appIcon
            // 
            this.appIcon.Text = "FilterBox";
            this.appIcon.Visible = true;
            this.appIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.appIcon_onShowClick);
            // 
            // scanButton
            // 
            this.scanButton.BackColor = System.Drawing.Color.DarkTurquoise;
            this.scanButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scanButton.FlatAppearance.BorderSize = 0;
            this.scanButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.scanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scanButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scanButton.Location = new System.Drawing.Point(0, 381);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(572, 63);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "Manually scan folder";
            this.scanButton.UseVisualStyleBackColor = false;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterLabel.Location = new System.Drawing.Point(6, 1);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(62, 25);
            this.filterLabel.TabIndex = 1;
            this.filterLabel.Text = "Filters";
            // 
            // addFilter
            // 
            this.addFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFilter.BackColor = System.Drawing.Color.SpringGreen;
            this.addFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.addFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFilter.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addFilter.Location = new System.Drawing.Point(455, 336);
            this.addFilter.Name = "addFilter";
            this.addFilter.Size = new System.Drawing.Size(105, 39);
            this.addFilter.TabIndex = 3;
            this.addFilter.Text = "Add";
            this.addFilter.UseVisualStyleBackColor = false;
            this.addFilter.Click += new System.EventHandler(this.addFilter_Click);
            // 
            // addFilterInput
            // 
            this.addFilterInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addFilterInput.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addFilterInput.Location = new System.Drawing.Point(108, 336);
            this.addFilterInput.Name = "addFilterInput";
            this.addFilterInput.PlaceholderText = "Input new filter here";
            this.addFilterInput.Size = new System.Drawing.Size(341, 39);
            this.addFilterInput.TabIndex = 4;
            // 
            // removeFilter
            // 
            this.removeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeFilter.BackColor = System.Drawing.Color.Red;
            this.removeFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.removeFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeFilter.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeFilter.Location = new System.Drawing.Point(12, 263);
            this.removeFilter.Name = "removeFilter";
            this.removeFilter.Size = new System.Drawing.Size(548, 48);
            this.removeFilter.TabIndex = 5;
            this.removeFilter.Text = "Remove Filter";
            this.removeFilter.UseVisualStyleBackColor = false;
            this.removeFilter.Click += new System.EventHandler(this.removeFilter_Click);
            // 
            // addFilterTypeFolder
            // 
            this.addFilterTypeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFilterTypeFolder.AutoSize = true;
            this.addFilterTypeFolder.BackColor = System.Drawing.Color.Transparent;
            this.addFilterTypeFolder.Checked = true;
            this.addFilterTypeFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addFilterTypeFolder.Location = new System.Drawing.Point(12, 338);
            this.addFilterTypeFolder.Name = "addFilterTypeFolder";
            this.addFilterTypeFolder.Size = new System.Drawing.Size(59, 19);
            this.addFilterTypeFolder.TabIndex = 6;
            this.addFilterTypeFolder.Text = "Folder";
            this.addFilterTypeFolder.UseVisualStyleBackColor = false;
            // 
            // addFilterTypeFile
            // 
            this.addFilterTypeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFilterTypeFile.AutoSize = true;
            this.addFilterTypeFile.BackColor = System.Drawing.Color.Transparent;
            this.addFilterTypeFile.Location = new System.Drawing.Point(12, 354);
            this.addFilterTypeFile.Name = "addFilterTypeFile";
            this.addFilterTypeFile.Size = new System.Drawing.Size(44, 19);
            this.addFilterTypeFile.TabIndex = 7;
            this.addFilterTypeFile.Text = "File";
            this.addFilterTypeFile.UseVisualStyleBackColor = false;
            // 
            // addFilterTypeLabel
            // 
            this.addFilterTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFilterTypeLabel.AutoSize = true;
            this.addFilterTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.addFilterTypeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addFilterTypeLabel.Location = new System.Drawing.Point(7, 314);
            this.addFilterTypeLabel.Name = "addFilterTypeLabel";
            this.addFilterTypeLabel.Size = new System.Drawing.Size(89, 21);
            this.addFilterTypeLabel.TabIndex = 8;
            this.addFilterTypeLabel.Text = "Filter Type";
            // 
            // addFilterInputLabel
            // 
            this.addFilterInputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFilterInputLabel.AutoSize = true;
            this.addFilterInputLabel.BackColor = System.Drawing.Color.Transparent;
            this.addFilterInputLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addFilterInputLabel.Location = new System.Drawing.Point(106, 314);
            this.addFilterInputLabel.Name = "addFilterInputLabel";
            this.addFilterInputLabel.Size = new System.Drawing.Size(49, 21);
            this.addFilterInputLabel.TabIndex = 9;
            this.addFilterInputLabel.Text = "Filter";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 444);
            this.Controls.Add(this.addFilterInputLabel);
            this.Controls.Add(this.addFilterTypeLabel);
            this.Controls.Add(this.addFilterTypeFile);
            this.Controls.Add(this.addFilterTypeFolder);
            this.Controls.Add(this.removeFilter);
            this.Controls.Add(this.addFilterInput);
            this.Controls.Add(this.addFilter);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.scanButton);
            this.Name = "Main";
            this.Text = "FilterBox";
            this.Load += new System.EventHandler(this.onMainLoaded);
            this.Resize += new System.EventHandler(this.MainResized);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon appIcon;
        private Button scanButton;
        private Label filterLabel;
        private Button addFilter;
        private TextBox addFilterInput;
        private Button removeFilter;
        private CheckBox addFilterTypeFolder;
        private CheckBox addFilterTypeFile;
        private Label addFilterTypeLabel;
        private Label addFilterInputLabel;
        private ListViewEx<assets.Filter> filterList;
    }
}