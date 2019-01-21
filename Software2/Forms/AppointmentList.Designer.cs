namespace Software2.Forms
{
    partial class AppointmentList
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
            this.backButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.appointmentTable = new System.Windows.Forms.DataGridView();
            this.titleLabel = new System.Windows.Forms.Label();
            this.viewByComboBox = new System.Windows.Forms.ComboBox();
            this.ViewByLabel = new System.Windows.Forms.Label();
            this.viewByButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(31, 392);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(94, 31);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(420, 392);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(94, 31);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(548, 392);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(94, 31);
            this.editButton.TabIndex = 7;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(676, 392);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 31);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // appointmentTable
            // 
            this.appointmentTable.AllowUserToAddRows = false;
            this.appointmentTable.AllowUserToDeleteRows = false;
            this.appointmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.appointmentTable.Location = new System.Drawing.Point(31, 68);
            this.appointmentTable.MultiSelect = false;
            this.appointmentTable.Name = "appointmentTable";
            this.appointmentTable.ReadOnly = true;
            this.appointmentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentTable.Size = new System.Drawing.Size(739, 295);
            this.appointmentTable.TabIndex = 5;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(312, 28);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(171, 24);
            this.titleLabel.TabIndex = 22;
            this.titleLabel.Text = "APPOINTMENTS";
            // 
            // viewByComboBox
            // 
            this.viewByComboBox.FormattingEnabled = true;
            this.viewByComboBox.Location = new System.Drawing.Point(567, 30);
            this.viewByComboBox.Name = "viewByComboBox";
            this.viewByComboBox.Size = new System.Drawing.Size(121, 21);
            this.viewByComboBox.TabIndex = 23;
            // 
            // ViewByLabel
            // 
            this.ViewByLabel.AutoSize = true;
            this.ViewByLabel.Location = new System.Drawing.Point(518, 36);
            this.ViewByLabel.Name = "ViewByLabel";
            this.ViewByLabel.Size = new System.Drawing.Size(45, 13);
            this.ViewByLabel.TabIndex = 24;
            this.ViewByLabel.Text = "View By";
            // 
            // viewByButton
            // 
            this.viewByButton.Location = new System.Drawing.Point(695, 28);
            this.viewByButton.Name = "viewByButton";
            this.viewByButton.Size = new System.Drawing.Size(75, 23);
            this.viewByButton.TabIndex = 25;
            this.viewByButton.Text = "Apply";
            this.viewByButton.UseVisualStyleBackColor = true;
            this.viewByButton.Click += new System.EventHandler(this.viewByButton_Click);
            // 
            // AppointmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewByButton);
            this.Controls.Add(this.ViewByLabel);
            this.Controls.Add(this.viewByComboBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.appointmentTable);
            this.Name = "AppointmentList";
            this.Text = "AppointmentList";
            this.Load += new System.EventHandler(this.AppointmentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView appointmentTable;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox viewByComboBox;
        private System.Windows.Forms.Label ViewByLabel;
        private System.Windows.Forms.Button viewByButton;
    }
}