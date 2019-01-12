namespace Software2.Forms.Reports
{
    partial class ReportSelect
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
            this.customerReportsButton = new System.Windows.Forms.Button();
            this.appointmentTypeReportsButton = new System.Windows.Forms.Button();
            this.customerAppointmentReportsButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customerReportsButton
            // 
            this.customerReportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerReportsButton.Location = new System.Drawing.Point(225, 162);
            this.customerReportsButton.Name = "customerReportsButton";
            this.customerReportsButton.Size = new System.Drawing.Size(329, 37);
            this.customerReportsButton.TabIndex = 3;
            this.customerReportsButton.Text = "Consultant Schedule Reports";
            this.customerReportsButton.UseVisualStyleBackColor = true;
            this.customerReportsButton.Click += new System.EventHandler(this.customerReportsButton_Click);
            // 
            // appointmentTypeReportsButton
            // 
            this.appointmentTypeReportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentTypeReportsButton.Location = new System.Drawing.Point(225, 222);
            this.appointmentTypeReportsButton.Name = "appointmentTypeReportsButton";
            this.appointmentTypeReportsButton.Size = new System.Drawing.Size(329, 37);
            this.appointmentTypeReportsButton.TabIndex = 4;
            this.appointmentTypeReportsButton.Text = "Appointment Type Reports";
            this.appointmentTypeReportsButton.UseVisualStyleBackColor = true;
            this.appointmentTypeReportsButton.Click += new System.EventHandler(this.appointmentTypeReportsButton_Click);
            // 
            // customerAppointmentReportsButton
            // 
            this.customerAppointmentReportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerAppointmentReportsButton.Location = new System.Drawing.Point(225, 281);
            this.customerAppointmentReportsButton.Name = "customerAppointmentReportsButton";
            this.customerAppointmentReportsButton.Size = new System.Drawing.Size(329, 37);
            this.customerAppointmentReportsButton.TabIndex = 5;
            this.customerAppointmentReportsButton.Text = "Customer Appointment Reports";
            this.customerAppointmentReportsButton.UseVisualStyleBackColor = true;
            this.customerAppointmentReportsButton.Click += new System.EventHandler(this.customerAppointmentReportsButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(38, 395);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(98, 29);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(310, 22);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(153, 31);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "REPORTS";
            // 
            // ReportSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.customerAppointmentReportsButton);
            this.Controls.Add(this.appointmentTypeReportsButton);
            this.Controls.Add(this.customerReportsButton);
            this.Name = "ReportSelect";
            this.Text = "ReportSelect";
            this.Load += new System.EventHandler(this.ReportSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button customerReportsButton;
        private System.Windows.Forms.Button appointmentTypeReportsButton;
        private System.Windows.Forms.Button customerAppointmentReportsButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label titleLabel;
    }
}