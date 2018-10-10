namespace Software2.Forms
{
    partial class Home
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
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.createAppointmentButton = new System.Windows.Forms.Button();
            this.signInButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Location = new System.Drawing.Point(150, 209);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(500, 45);
            this.addCustomerButton.TabIndex = 0;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // createAppointmentButton
            // 
            this.createAppointmentButton.Location = new System.Drawing.Point(150, 277);
            this.createAppointmentButton.Name = "createAppointmentButton";
            this.createAppointmentButton.Size = new System.Drawing.Size(500, 42);
            this.createAppointmentButton.TabIndex = 1;
            this.createAppointmentButton.Text = "Create Appointment";
            this.createAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(357, 254);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(75, 23);
            this.signInButton.TabIndex = 2;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(366, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "APPOINTMENTS 4 YOU";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 521);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.createAppointmentButton);
            this.Controls.Add(this.addCustomerButton);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button createAppointmentButton;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Label label2;
    }
}