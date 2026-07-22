namespace Lab5
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.WhenMostEventsBtn = new System.Windows.Forms.Button();
            this.ShowChartsBtn = new System.Windows.Forms.Button();
            this.FromDateLbl = new System.Windows.Forms.Label();
            this.ToDateLbl = new System.Windows.Forms.Label();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FinishBtn = new System.Windows.Forms.Button();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ShowAllBtn = new System.Windows.Forms.Button();
            this.FilterByDateBtn = new System.Windows.Forms.Button();
            this.CountAllBtn = new System.Windows.Forms.Button();
            this.CountByTypeBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.WhenMostEventsBtn);
            this.panel1.Controls.Add(this.ShowChartsBtn);
            this.panel1.Controls.Add(this.FromDateLbl);
            this.panel1.Controls.Add(this.ToDateLbl);
            this.panel1.Controls.Add(this.ToDateTimePicker);
            this.panel1.Controls.Add(this.FinishBtn);
            this.panel1.Controls.Add(this.FromDateTimePicker);
            this.panel1.Controls.Add(this.ShowAllBtn);
            this.panel1.Controls.Add(this.FilterByDateBtn);
            this.panel1.Controls.Add(this.CountAllBtn);
            this.panel1.Controls.Add(this.CountByTypeBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 83);
            this.panel1.TabIndex = 0;
            // 
            // WhenMostEventsBtn
            // 
            this.WhenMostEventsBtn.Location = new System.Drawing.Point(580, 30);
            this.WhenMostEventsBtn.Name = "WhenMostEventsBtn";
            this.WhenMostEventsBtn.Size = new System.Drawing.Size(163, 23);
            this.WhenMostEventsBtn.TabIndex = 10;
            this.WhenMostEventsBtn.Text = "When Most Events ";
            this.WhenMostEventsBtn.UseVisualStyleBackColor = true;
            this.WhenMostEventsBtn.Click += new System.EventHandler(this.WhenMostEventsBtn_Click);
            // 
            // ShowChartsBtn
            // 
            this.ShowChartsBtn.Location = new System.Drawing.Point(461, 30);
            this.ShowChartsBtn.Name = "ShowChartsBtn";
            this.ShowChartsBtn.Size = new System.Drawing.Size(113, 23);
            this.ShowChartsBtn.TabIndex = 9;
            this.ShowChartsBtn.Text = "Show Charts";
            this.ShowChartsBtn.UseVisualStyleBackColor = true;
            this.ShowChartsBtn.Click += new System.EventHandler(this.ShowChartsBtn_Click);
            // 
            // FromDateLbl
            // 
            this.FromDateLbl.Location = new System.Drawing.Point(814, 12);
            this.FromDateLbl.Name = "FromDateLbl";
            this.FromDateLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FromDateLbl.Size = new System.Drawing.Size(86, 21);
            this.FromDateLbl.TabIndex = 8;
            this.FromDateLbl.Text = ":From Date";
            // 
            // ToDateLbl
            // 
            this.ToDateLbl.Location = new System.Drawing.Point(814, 36);
            this.ToDateLbl.Name = "ToDateLbl";
            this.ToDateLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToDateLbl.Size = new System.Drawing.Size(86, 21);
            this.ToDateLbl.TabIndex = 7;
            this.ToDateLbl.Text = ":To Date";
            // 
            // ToDateTimePicker
            // 
            this.ToDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.ToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDateTimePicker.Location = new System.Drawing.Point(906, 35);
            this.ToDateTimePicker.Name = "ToDateTimePicker";
            this.ToDateTimePicker.Size = new System.Drawing.Size(183, 22);
            this.ToDateTimePicker.TabIndex = 3;
            // 
            // FinishBtn
            // 
            this.FinishBtn.Location = new System.Drawing.Point(1132, 30);
            this.FinishBtn.Name = "FinishBtn";
            this.FinishBtn.Size = new System.Drawing.Size(75, 23);
            this.FinishBtn.TabIndex = 6;
            this.FinishBtn.Text = "Finish";
            this.FinishBtn.UseVisualStyleBackColor = true;
            this.FinishBtn.Click += new System.EventHandler(this.FinishBtn_Click);
            // 
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.FromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDateTimePicker.Location = new System.Drawing.Point(906, 12);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(183, 22);
            this.FromDateTimePicker.TabIndex = 1;
            // 
            // ShowAllBtn
            // 
            this.ShowAllBtn.Location = new System.Drawing.Point(12, 30);
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(90, 23);
            this.ShowAllBtn.TabIndex = 4;
            this.ShowAllBtn.Text = "Show All";
            this.ShowAllBtn.UseVisualStyleBackColor = true;
            this.ShowAllBtn.Click += new System.EventHandler(this.ShowAllBtn_Click);
            // 
            // FilterByDateBtn
            // 
            this.FilterByDateBtn.Location = new System.Drawing.Point(342, 30);
            this.FilterByDateBtn.Name = "FilterByDateBtn";
            this.FilterByDateBtn.Size = new System.Drawing.Size(113, 23);
            this.FilterByDateBtn.TabIndex = 5;
            this.FilterByDateBtn.Text = "Filter By Date";
            this.FilterByDateBtn.UseVisualStyleBackColor = true;
            this.FilterByDateBtn.Click += new System.EventHandler(this.FilterByDateBtn_Click);
            // 
            // CountAllBtn
            // 
            this.CountAllBtn.Location = new System.Drawing.Point(108, 30);
            this.CountAllBtn.Name = "CountAllBtn";
            this.CountAllBtn.Size = new System.Drawing.Size(97, 23);
            this.CountAllBtn.TabIndex = 2;
            this.CountAllBtn.Text = "Count All";
            this.CountAllBtn.UseVisualStyleBackColor = true;
            this.CountAllBtn.Click += new System.EventHandler(this.CountAllBtn_Click);
            // 
            // CountByTypeBtn
            // 
            this.CountByTypeBtn.Location = new System.Drawing.Point(211, 30);
            this.CountByTypeBtn.Name = "CountByTypeBtn";
            this.CountByTypeBtn.Size = new System.Drawing.Size(125, 23);
            this.CountByTypeBtn.TabIndex = 3;
            this.CountByTypeBtn.Text = "Count By Type\r\n";
            this.CountByTypeBtn.UseVisualStyleBackColor = true;
            this.CountByTypeBtn.Click += new System.EventHandler(this.CountByTypeBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1219, 627);
            this.dataGridView1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1219, 724);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button WhenMostEventsBtn;

        private System.Windows.Forms.Button ShowChartsBtn;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Label FromDateLbl;

        private System.Windows.Forms.Label ToDateLbl;

        private System.Windows.Forms.DateTimePicker ToDateTimePicker;

        private System.Windows.Forms.DateTimePicker FromDateTimePicker;

        private System.Windows.Forms.Button ShowAllBtn;
        private System.Windows.Forms.Button CountAllBtn;
        private System.Windows.Forms.Button CountByTypeBtn;
        private System.Windows.Forms.Button FilterByDateBtn;
        private System.Windows.Forms.Button FinishBtn;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}