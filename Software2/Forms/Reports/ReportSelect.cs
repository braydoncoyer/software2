
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2.Forms.Reports
{
    public partial class ReportSelect : Form
    {
        private string username;
        public ReportSelect()
        {
            InitializeComponent();
        }

        public ReportSelect(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void ReportSelect_Load(object sender, EventArgs e)
        {

        }

        private void goToReportForm(int mode)
        {
            ReportDataSelection reportSelection = new ReportDataSelection(username, mode);
            reportSelection.Show();
            this.Close();
        }

        private void customerReportsButton_Click(object sender, EventArgs e)
        {
            goToReportForm(0);
        }

        private void appointmentTypeReportsButton_Click(object sender, EventArgs e)
        {
            goToReportForm(1);
        }

        private void customerAppointmentReportsButton_Click(object sender, EventArgs e)
        {
            goToReportForm(2);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main(username);
            mainForm.Show();
            this.Close();
        }
    }
}
