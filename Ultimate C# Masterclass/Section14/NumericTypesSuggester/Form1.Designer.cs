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
			minValTxtBx = new TextBox();
			maxValueTxtBx = new TextBox();
			integralChckBx = new CheckBox();
			preciseChBx = new CheckBox();
			typeSuggestionLbl = new Label();
			maxValueLbl = new Label();
			minValueLbl = new Label();
			SuspendLayout();
			// 
			// minValTxtBx
			// 
			minValTxtBx.Location = new Point(175, 12);
			minValTxtBx.Name = "minValTxtBx";
			minValTxtBx.Size = new Size(579, 27);
			minValTxtBx.TabIndex = 0;
			// 
			// maxValueTxtBx
			// 
			maxValueTxtBx.Location = new Point(175, 55);
			maxValueTxtBx.Name = "maxValueTxtBx";
			maxValueTxtBx.Size = new Size(579, 27);
			maxValueTxtBx.TabIndex = 1;
			// 
			// integralChckBx
			// 
			integralChckBx.AutoSize = true;
			integralChckBx.CheckAlign = ContentAlignment.MiddleRight;
			integralChckBx.Checked = true;
			integralChckBx.CheckState = CheckState.Checked;
			integralChckBx.Location = new Point(72, 103);
			integralChckBx.Name = "integralChckBx";
			integralChckBx.Size = new Size(121, 24);
			integralChckBx.TabIndex = 2;
			integralChckBx.Text = "Integral only?";
			integralChckBx.UseVisualStyleBackColor = true;
			// 
			// preciseChBx
			// 
			preciseChBx.AutoSize = true;
			preciseChBx.CheckAlign = ContentAlignment.MiddleRight;
			preciseChBx.Location = new Point(51, 133);
			preciseChBx.Name = "preciseChBx";
			preciseChBx.Size = new Size(142, 24);
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
			typeSuggestionLbl.Location = new Point(31, 174);
			typeSuggestionLbl.Name = "typeSuggestionLbl";
			typeSuggestionLbl.Size = new Size(241, 20);
			typeSuggestionLbl.TabIndex = 4;
			typeSuggestionLbl.Text = "Suggested type: not enough data";
			// 
			// maxValueLbl
			// 
			maxValueLbl.AutoSize = true;
			maxValueLbl.Location = new Point(89, 62);
			maxValueLbl.Name = "maxValueLbl";
			maxValueLbl.Size = new Size(80, 20);
			maxValueLbl.TabIndex = 5;
			maxValueLbl.Text = "Max Value:";
			// 
			// minValueLbl
			// 
			minValueLbl.AutoSize = true;
			minValueLbl.Location = new Point(92, 19);
			minValueLbl.Name = "minValueLbl";
			minValueLbl.Size = new Size(77, 20);
			minValueLbl.TabIndex = 6;
			minValueLbl.Text = "Min Value:";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 217);
			Controls.Add(minValueLbl);
			Controls.Add(maxValueLbl);
			Controls.Add(typeSuggestionLbl);
			Controls.Add(preciseChBx);
			Controls.Add(integralChckBx);
			Controls.Add(maxValueTxtBx);
			Controls.Add(minValTxtBx);
			Cursor = Cursors.Default;
			ForeColor = SystemColors.ControlText;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "Form1";
			Text = "C# Numeric Types";
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox minValTxtBx;
		private TextBox maxValueTxtBx;
		private CheckBox integralChckBx;
		private CheckBox preciseChBx;
		private Label typeSuggestionLbl;
		private Label maxValueLbl;
		private Label minValueLbl;
	}
}
