namespace Lab2
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.TextFilePath = new System.Windows.Forms.TextBox();
			this.BtnImport = new System.Windows.Forms.Button();
			this.BtnBrowse = new System.Windows.Forms.Button();
			this.ListBox1 = new System.Windows.Forms.ListBox();
			this.ListBox2 = new System.Windows.Forms.ListBox();
			this.ListBox3 = new System.Windows.Forms.ListBox();
			this.ListBox4 = new System.Windows.Forms.ListBox();
			this.ListBox5 = new System.Windows.Forms.ListBox();
			this.ListBox6 = new System.Windows.Forms.ListBox();
			this.ListBox7 = new System.Windows.Forms.ListBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.LblLoadedLines = new System.Windows.Forms.Label();
			this.BtnAbout = new System.Windows.Forms.Button();
			this.BtnBrowseFolder = new System.Windows.Forms.Button();
			this.BtnImportFolder = new System.Windows.Forms.Button();
			this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.TextAutoFolderPath = new System.Windows.Forms.TextBox();
			this.NumUpdateInterval = new System.Windows.Forms.NumericUpDown();
			this.BtnToggleUpdate = new System.Windows.Forms.Button();
			this.LblOrchestratorStatus = new System.Windows.Forms.Label();
			this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.NumUpdateInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// TextFilePath
			// 
			this.TextFilePath.Location = new System.Drawing.Point(461, 22);
			this.TextFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextFilePath.Name = "TextFilePath";
			this.TextFilePath.Size = new System.Drawing.Size(529, 22);
			this.TextFilePath.TabIndex = 0;
			this.TextFilePath.Text = "provide a file path here";
			// 
			// BtnImport
			// 
			this.BtnImport.Location = new System.Drawing.Point(311, 11);
			this.BtnImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.BtnImport.Name = "BtnImport";
			this.BtnImport.Size = new System.Drawing.Size(75, 43);
			this.BtnImport.TabIndex = 1;
			this.BtnImport.Text = "Read File";
			this.BtnImport.UseVisualStyleBackColor = true;
			this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
			// 
			// BtnBrowse
			// 
			this.BtnBrowse.Location = new System.Drawing.Point(215, 11);
			this.BtnBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.BtnBrowse.Name = "BtnBrowse";
			this.BtnBrowse.Size = new System.Drawing.Size(75, 43);
			this.BtnBrowse.TabIndex = 2;
			this.BtnBrowse.Text = "File";
			this.BtnBrowse.UseVisualStyleBackColor = true;
			this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
			// 
			// ListBox1
			// 
			this.ListBox1.FormattingEnabled = true;
			this.ListBox1.ItemHeight = 16;
			this.ListBox1.Location = new System.Drawing.Point(13, 70);
			this.ListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBox1.Name = "ListBox1";
			this.ListBox1.ScrollAlwaysVisible = true;
			this.ListBox1.Size = new System.Drawing.Size(1357, 180);
			this.ListBox1.TabIndex = 6;
			// 
			// ListBox2
			// 
			this.ListBox2.FormattingEnabled = true;
			this.ListBox2.ItemHeight = 16;
			this.ListBox2.Location = new System.Drawing.Point(13, 268);
			this.ListBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBox2.Name = "ListBox2";
			this.ListBox2.ScrollAlwaysVisible = true;
			this.ListBox2.Size = new System.Drawing.Size(218, 180);
			this.ListBox2.TabIndex = 7;
			// 
			// ListBox3
			// 
			this.ListBox3.FormattingEnabled = true;
			this.ListBox3.ItemHeight = 16;
			this.ListBox3.Location = new System.Drawing.Point(237, 268);
			this.ListBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBox3.Name = "ListBox3";
			this.ListBox3.ScrollAlwaysVisible = true;
			this.ListBox3.Size = new System.Drawing.Size(218, 180);
			this.ListBox3.TabIndex = 8;
			// 
			// ListBox4
			// 
			this.ListBox4.FormattingEnabled = true;
			this.ListBox4.ItemHeight = 16;
			this.ListBox4.Location = new System.Drawing.Point(461, 268);
			this.ListBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBox4.Name = "ListBox4";
			this.ListBox4.ScrollAlwaysVisible = true;
			this.ListBox4.Size = new System.Drawing.Size(218, 180);
			this.ListBox4.TabIndex = 9;
			// 
			// ListBox5
			// 
			this.ListBox5.FormattingEnabled = true;
			this.ListBox5.ItemHeight = 16;
			this.ListBox5.Location = new System.Drawing.Point(685, 268);
			this.ListBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBox5.Name = "ListBox5";
			this.ListBox5.ScrollAlwaysVisible = true;
			this.ListBox5.Size = new System.Drawing.Size(218, 180);
			this.ListBox5.TabIndex = 10;
			// 
			// ListBox6
			// 
			this.ListBox6.FormattingEnabled = true;
			this.ListBox6.ItemHeight = 16;
			this.ListBox6.Location = new System.Drawing.Point(909, 268);
			this.ListBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBox6.Name = "ListBox6";
			this.ListBox6.ScrollAlwaysVisible = true;
			this.ListBox6.Size = new System.Drawing.Size(218, 180);
			this.ListBox6.TabIndex = 11;
			// 
			// ListBox7
			// 
			this.ListBox7.FormattingEnabled = true;
			this.ListBox7.ItemHeight = 16;
			this.ListBox7.Location = new System.Drawing.Point(1133, 268);
			this.ListBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ListBox7.Name = "ListBox7";
			this.ListBox7.ScrollAlwaysVisible = true;
			this.ListBox7.Size = new System.Drawing.Size(218, 180);
			this.ListBox7.TabIndex = 12;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// LblLoadedLines
			// 
			this.LblLoadedLines.AutoSize = true;
			this.LblLoadedLines.Location = new System.Drawing.Point(8, 455);
			this.LblLoadedLines.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LblLoadedLines.Name = "LblLoadedLines";
			this.LblLoadedLines.Size = new System.Drawing.Size(267, 17);
			this.LblLoadedLines.TabIndex = 13;
			this.LblLoadedLines.Tag = "LblLoadedLines";
			this.LblLoadedLines.Text = "The number of loaded file lines of data: 0";
			// 
			// BtnAbout
			// 
			this.BtnAbout.Location = new System.Drawing.Point(-1, 0);
			this.BtnAbout.Margin = new System.Windows.Forms.Padding(4);
			this.BtnAbout.Name = "BtnAbout";
			this.BtnAbout.Size = new System.Drawing.Size(133, 31);
			this.BtnAbout.TabIndex = 14;
			this.BtnAbout.Text = "About";
			this.BtnAbout.UseVisualStyleBackColor = true;
			this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
			// 
			// BtnBrowseFolder
			// 
			this.BtnBrowseFolder.Location = new System.Drawing.Point(1052, 15);
			this.BtnBrowseFolder.Name = "BtnBrowseFolder";
			this.BtnBrowseFolder.Size = new System.Drawing.Size(75, 39);
			this.BtnBrowseFolder.TabIndex = 15;
			this.BtnBrowseFolder.Text = "Folder";
			this.BtnBrowseFolder.UseVisualStyleBackColor = true;
			this.BtnBrowseFolder.Click += new System.EventHandler(this.BtnBrowseFolder_Click);
			// 
			// BtnImportFolder
			// 
			this.BtnImportFolder.Location = new System.Drawing.Point(1152, 15);
			this.BtnImportFolder.Name = "BtnImportFolder";
			this.BtnImportFolder.Size = new System.Drawing.Size(102, 39);
			this.BtnImportFolder.TabIndex = 16;
			this.BtnImportFolder.Text = "Read All Files";
			this.BtnImportFolder.UseVisualStyleBackColor = true;
			this.BtnImportFolder.Click += new System.EventHandler(this.BtnImportFolder_Click);
			// 
			//
			// TextAutoFolderPath
			//
			this.TextAutoFolderPath.Location = new System.Drawing.Point(13, 480);
			this.TextAutoFolderPath.Name = "TextAutoFolderPath";
			this.TextAutoFolderPath.Size = new System.Drawing.Size(529, 22);
			this.TextAutoFolderPath.TabIndex = 17;
			this.TextAutoFolderPath.Text = @"C:\Users\kacperkowalski\Downloads\db";
			//
			// NumUpdateInterval
			//
			this.NumUpdateInterval.Location = new System.Drawing.Point(558, 481);
			this.NumUpdateInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.NumUpdateInterval.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
			this.NumUpdateInterval.Value = new decimal(new int[] { 30, 0, 0, 0 });
			this.NumUpdateInterval.Name = "NumUpdateInterval";
			this.NumUpdateInterval.Size = new System.Drawing.Size(80, 22);
			this.NumUpdateInterval.TabIndex = 18;
			//
			// BtnToggleUpdate
			//
			this.BtnToggleUpdate.Location = new System.Drawing.Point(654, 477);
			this.BtnToggleUpdate.Name = "BtnToggleUpdate";
			this.BtnToggleUpdate.Size = new System.Drawing.Size(180, 30);
			this.BtnToggleUpdate.TabIndex = 19;
			this.BtnToggleUpdate.Text = "Enable updates";
			this.BtnToggleUpdate.UseVisualStyleBackColor = true;
			this.BtnToggleUpdate.Click += new System.EventHandler(this.BtnToggleUpdate_Click);
			//
			// LblOrchestratorStatus
			//
			this.LblOrchestratorStatus.AutoSize = true;
			this.LblOrchestratorStatus.Location = new System.Drawing.Point(850, 483);
			this.LblOrchestratorStatus.Name = "LblOrchestratorStatus";
			this.LblOrchestratorStatus.Size = new System.Drawing.Size(100, 17);
			this.LblOrchestratorStatus.TabIndex = 20;
			this.LblOrchestratorStatus.Text = "Orchestrator: OFF";
			//
			// UpdateTimer
			//
			this.UpdateTimer.Interval = 30000;
			this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
			//
			// Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1382, 520);
			this.Controls.Add(this.LblOrchestratorStatus);
			this.Controls.Add(this.BtnToggleUpdate);
			this.Controls.Add(this.NumUpdateInterval);
			this.Controls.Add(this.TextAutoFolderPath);
			this.Controls.Add(this.BtnImportFolder);
			this.Controls.Add(this.BtnBrowseFolder);
			this.Controls.Add(this.BtnAbout);
			this.Controls.Add(this.LblLoadedLines);
			this.Controls.Add(this.ListBox7);
			this.Controls.Add(this.ListBox6);
			this.Controls.Add(this.ListBox5);
			this.Controls.Add(this.ListBox4);
			this.Controls.Add(this.ListBox3);
			this.Controls.Add(this.ListBox2);
			this.Controls.Add(this.ListBox1);
			this.Controls.Add(this.BtnBrowse);
			this.Controls.Add(this.BtnImport);
			this.Controls.Add(this.TextFilePath);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.Text = "Lab4 - ETL Orkiestrator";
			((System.ComponentModel.ISupportInitialize)(this.NumUpdateInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.TextBox TextFilePath;
		private System.Windows.Forms.Button BtnImport;
		private System.Windows.Forms.Button BtnBrowse;
		private System.Windows.Forms.ListBox ListBox1;
		private System.Windows.Forms.ListBox ListBox2;
		private System.Windows.Forms.ListBox ListBox3;
		private System.Windows.Forms.ListBox ListBox4;
		private System.Windows.Forms.ListBox ListBox5;
		private System.Windows.Forms.ListBox ListBox6;
		private System.Windows.Forms.ListBox ListBox7;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label LblLoadedLines;
		private System.Windows.Forms.Button BtnAbout;
		private System.Windows.Forms.Button BtnBrowseFolder;
		private System.Windows.Forms.Button BtnImportFolder;
		private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
		private System.Windows.Forms.TextBox TextAutoFolderPath;
		private System.Windows.Forms.NumericUpDown NumUpdateInterval;
		private System.Windows.Forms.Button BtnToggleUpdate;
		private System.Windows.Forms.Label LblOrchestratorStatus;
		private System.Windows.Forms.Timer UpdateTimer;
	}
}
