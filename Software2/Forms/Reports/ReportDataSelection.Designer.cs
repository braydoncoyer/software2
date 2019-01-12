namespace Software2.Forms.Reports
{
    partial class ReportDataSelection
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.continueButton = new System.Windows.Forms.Button();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(105, 38);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(276, 24);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "REPORT DATA SELECTION";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(153, 173);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(176, 21);
            this.typeComboBox.TabIndex = 28;
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(365, 272);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(98, 29);
            this.continueButton.TabIndex = 29;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // startDatePicker
            // 
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDatePicker.Location = new System.Drawing.Point(163, 121);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(157, 20);
            this.startDatePicker.TabIndex = 30;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(34, 272);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(98, 29);
            this.backButton.TabIndex = 31;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ReportDataSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 326);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.titleLabel);
            this.Name = "ReportDataSelection";
            this.Text = "ReportDataSelection";
            this.Load += new System.EventHandler(this.ReportDataSelection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Button backButton;
    }
}