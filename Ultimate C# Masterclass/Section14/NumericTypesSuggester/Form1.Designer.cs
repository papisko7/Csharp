namespace NumericTypesSuggester
{
    partial class Form1
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
            minValueTxtBx = new TextBox();
            maxValueTxtBx = new TextBox();
            integralChckBx = new CheckBox();
            preciseChBx = new CheckBox();
            typeSuggestionLbl = new Label();
            maxValueLbl = new Label();
            minValueLbl = new Label();
            SuspendLayout();
            // 
            // minValueTxtBx
            // 
            minValueTxtBx.Location = new Point(153, 9);
            minValueTxtBx.Margin = new Padding(3, 2, 3, 2);
            minValueTxtBx.Name = "minValueTxtBx";
            minValueTxtBx.Size = new Size(507, 23);
            minValueTxtBx.TabIndex = 0;
            // 
            // maxValueTxtBx
            // 
            maxValueTxtBx.Location = new Point(153, 41);
            maxValueTxtBx.Margin = new Padding(3, 2, 3, 2);
            maxValueTxtBx.Name = "maxValueTxtBx";
            maxValueTxtBx.Size = new Size(507, 23);
            maxValueTxtBx.TabIndex = 1;
            // 
            // integralChckBx
            // 
            integralChckBx.AutoSize = true;
            integralChckBx.CheckAlign = ContentAlignment.MiddleRight;
            integralChckBx.Checked = true;
            integralChckBx.CheckState = CheckState.Checked;
            integralChckBx.Location = new Point(63, 77);
            integralChckBx.Margin = new Padding(3, 2, 3, 2);
            integralChckBx.Name = "integralChckBx";
            integralChckBx.Size = new Size(97, 19);
            integralChckBx.TabIndex = 2;
            integralChckBx.Text = "Integral only?";
            integralChckBx.UseVisualStyleBackColor = true;
            // 
            // preciseChBx
            // 
            preciseChBx.AutoSize = true;
            preciseChBx.CheckAlign = ContentAlignment.MiddleRight;
            preciseChBx.Location = new Point(45, 100);
            preciseChBx.Margin = new Padding(3, 2, 3, 2);
            preciseChBx.Name = "preciseChBx";
            preciseChBx.Size = new Size(114, 19);
            preciseChBx.TabIndex = 3;
            preciseChBx.Text = "Must be precise?";
            preciseChBx.UseVisualStyleBackColor = true;
            preciseChBx.Visible = false;
            // 
            // typeSuggestionLbl
            // 
            typeSuggestionLbl.AutoSize = true;
            typeSuggestionLbl.BackColor = SystemColors.ActiveCaption;
            typeSuggestionLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            typeSuggestionLbl.Location = new Point(27, 130);
            typeSuggestionLbl.Name = "typeSuggestionLbl";
            typeSuggestionLbl.Size = new Size(191, 15);
            typeSuggestionLbl.TabIndex = 4;
            typeSuggestionLbl.Text = "Suggested type: not enough data";
            // 
            // maxValueLbl
            // 
            maxValueLbl.AutoSize = true;
            maxValueLbl.Location = new Point(78, 46);
            maxValueLbl.Name = "maxValueLbl";
            maxValueLbl.Size = new Size(63, 15);
            maxValueLbl.TabIndex = 5;
            maxValueLbl.Text = "Max Value:";
            // 
            // minValueLbl
            // 
            minValueLbl.AutoSize = true;
            minValueLbl.Location = new Point(80, 14);
            minValueLbl.Name = "minValueLbl";
            minValueLbl.Size = new Size(62, 15);
            minValueLbl.TabIndex = 6;
            minValueLbl.Text = "Min Value:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(700, 163);
            Controls.Add(minValueLbl);
            Controls.Add(maxValueLbl);
            Controls.Add(typeSuggestionLbl);
            Controls.Add(preciseChBx);
            Controls.Add(integralChckBx);
            Controls.Add(maxValueTxtBx);
            Controls.Add(minValueTxtBx);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "C# Numeric Types";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox minValueTxtBx;
		private TextBox maxValueTxtBx;
		private CheckBox integralChckBx;
		private CheckBox preciseChBx;
		private Label typeSuggestionLbl;
		private Label maxValueLbl;
		private Label minValueLbl;
	}
}
