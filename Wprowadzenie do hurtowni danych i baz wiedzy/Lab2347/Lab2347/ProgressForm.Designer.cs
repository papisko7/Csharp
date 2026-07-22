namespace Lab2
{
	partial class ProgressForm
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
			this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
			this.BtnStart = new System.Windows.Forms.Button();
			this.BtnStop = new System.Windows.Forms.Button();
			this.LblStatus = new System.Windows.Forms.Label();
			this.LblProcessedFiles = new System.Windows.Forms.Label();
			this.ListBoxFiles = new System.Windows.Forms.ListBox();
			this.LblTotalLines = new System.Windows.Forms.Label();
			this.BtnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// ProgressBar1
			//
			this.ProgressBar1.Location = new System.Drawing.Point(12, 12);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(460, 30);
			this.ProgressBar1.TabIndex = 0;
			//
			// BtnStart
			//
			this.BtnStart.Location = new System.Drawing.Point(490, 12);
			this.BtnStart.Name = "BtnStart";
			this.BtnStart.Size = new System.Drawing.Size(80, 30);
			this.BtnStart.TabIndex = 1;
			this.BtnStart.Text = "Start";
			this.BtnStart.UseVisualStyleBackColor = true;
			this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
			//
			// BtnStop
			//
			this.BtnStop.Enabled = false;
			this.BtnStop.Location = new System.Drawing.Point(580, 12);
			this.BtnStop.Name = "BtnStop";
			this.BtnStop.Size = new System.Drawing.Size(80, 30);
			this.BtnStop.TabIndex = 2;
			this.BtnStop.Text = "Stop";
			this.BtnStop.UseVisualStyleBackColor = true;
			this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
			//
			// LblStatus
			//
			this.LblStatus.AutoSize = true;
			this.LblStatus.Location = new System.Drawing.Point(12, 52);
			this.LblStatus.Name = "LblStatus";
			this.LblStatus.Size = new System.Drawing.Size(200, 16);
			this.LblStatus.TabIndex = 3;
			this.LblStatus.Text = "Click Start to begin processing.";
			//
			// LblProcessedFiles
			//
			this.LblProcessedFiles.AutoSize = true;
			this.LblProcessedFiles.Location = new System.Drawing.Point(12, 78);
			this.LblProcessedFiles.Name = "LblProcessedFiles";
			this.LblProcessedFiles.Size = new System.Drawing.Size(120, 16);
			this.LblProcessedFiles.TabIndex = 4;
			this.LblProcessedFiles.Text = "Processed files:";
			//
			// ListBoxFiles
			//
			this.ListBoxFiles.FormattingEnabled = true;
			this.ListBoxFiles.ItemHeight = 16;
			this.ListBoxFiles.Location = new System.Drawing.Point(12, 100);
			this.ListBoxFiles.Name = "ListBoxFiles";
			this.ListBoxFiles.ScrollAlwaysVisible = true;
			this.ListBoxFiles.Size = new System.Drawing.Size(648, 212);
			this.ListBoxFiles.TabIndex = 5;
			//
			// LblTotalLines
			//
			this.LblTotalLines.AutoSize = true;
			this.LblTotalLines.Location = new System.Drawing.Point(12, 322);
			this.LblTotalLines.Name = "LblTotalLines";
			this.LblTotalLines.Size = new System.Drawing.Size(150, 16);
			this.LblTotalLines.TabIndex = 6;
			this.LblTotalLines.Text = "Total lines read: 0";
			//
			// BtnClose
			//
			this.BtnClose.Enabled = false;
			this.BtnClose.Location = new System.Drawing.Point(560, 316);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(100, 30);
			this.BtnClose.TabIndex = 7;
			this.BtnClose.Text = "Close";
			this.BtnClose.UseVisualStyleBackColor = true;
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			//
			// ProgressForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(674, 351);
			this.Controls.Add(this.BtnClose);
			this.Controls.Add(this.LblTotalLines);
			this.Controls.Add(this.ListBoxFiles);
			this.Controls.Add(this.LblProcessedFiles);
			this.Controls.Add(this.LblStatus);
			this.Controls.Add(this.BtnStop);
			this.Controls.Add(this.BtnStart);
			this.Controls.Add(this.ProgressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgressForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Import Progress";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.ProgressBar ProgressBar1;
		private System.Windows.Forms.Button BtnStart;
		private System.Windows.Forms.Button BtnStop;
		private System.Windows.Forms.Label LblStatus;
		private System.Windows.Forms.Label LblProcessedFiles;
		private System.Windows.Forms.ListBox ListBoxFiles;
		private System.Windows.Forms.Label LblTotalLines;
		private System.Windows.Forms.Button BtnClose;
	}
}
