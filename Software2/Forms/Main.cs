using Software2.Forms;
using Software2.Forms.Reports;
using Software2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2
{
    public partial class Main : Form
    {
        string username;

        public Main()
        {
            InitializeComponent();
        }

        public Main(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerList customerList = new CustomerList(username);
            customerList.Show();
            this.Hide();
        }

        private void appointmentButton_Click(object sender, EventArgs e)
        {
            AppointmentList listForm = new AppointmentList(username);
            listForm.Show();
            this.Close();
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            ReportSelect reportSelectForm = new ReportSelect(username);
            reportSelectForm.Show();
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var _appointmentService = new AppointmentService(this.username);
            var upcomingAppointment = _appointmentService.getAppointmentsComingUp();
            if(upcomingAppointment != null)
            {
                MessageBox.Show(upcomingAppointment.title + " is coming up at " + upcomingAppointment.start);
            }
        }
    }
}
