using Software2.Services;
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
    public partial class ReportForm : Form
    {

        string username;
        private enum formMode { consultant = 0, appointment = 1, customer = 2 };
        int formmode;
        int dataID;
        DateTime monthData;
        AppointmentService _appointmentService;
        CustomerService _customerService;
        UserService _userService;

        public ReportForm()
        {
            InitializeComponent();
        }

        public ReportForm(string username, int mode, int id)
        {
            initData(username, mode);
            dataID = id;
            InitializeComponent();
        }

        public ReportForm(string username, int mode, DateTime month)
        {
            initData(username, mode);
            monthData = month;
            InitializeComponent();
        }

        private void initData(string username, int mode)
        {
            this.username = username;
            setFormMode(mode);
            _appointmentService = new AppointmentService(this.username);
            _customerService = new CustomerService(this.username);
            _userService = new UserService();
        }

        private void setFormMode(int mode)
        {
            switch (mode)
            {
                case 0:
                    this.formmode = (int)formMode.consultant;
                    break;

                case 1:
                    this.formmode = (int)formMode.appointment;
                    break;

                case 2:
                    this.formmode = (int)formMode.customer;
                    break;

                default:
                    break;
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            infoTextBox.ReadOnly = true;
            if (formmode == (int)formMode.consultant)
            {
                mapConsultantTextBox();
            }
            if (formmode == (int)formMode.customer)
            {
                mapCustomerTextBox();
            }
            if (formmode == (int)formMode.appointment)
            {
                mapAppointmentTextBox();
            }

        }

        private void mapAppointmentTextBox()
        {
            throw new NotImplementedException();
        }

        private void mapCustomerTextBox()
        {
            var appointments = _appointmentService.getAllAppointmentsForACustomer(dataID);

            foreach(var a in appointments)
            {
                infoTextBox.Text += Environment.NewLine;
                infoTextBox.Text += Environment.NewLine;
                infoTextBox.Text += Environment.NewLine + a.title;
                infoTextBox.Text += Environment.NewLine + "Customer: " + a.customer.customerName;
                infoTextBox.Text += Environment.NewLine + "Start: " + a.start;
                infoTextBox.Text += Environment.NewLine + "End: " + a.end;

            }
        }

        private void mapConsultantTextBox()
        {
            var appointments = _appointmentService.getAllAppointmentsForAUser(_userService.getUserNameByID(dataID));

            foreach (var a in appointments)
            {
                infoTextBox.Text += Environment.NewLine;
                infoTextBox.Text += Environment.NewLine;
                infoTextBox.Text += Environment.NewLine + a.title;
                infoTextBox.Text += Environment.NewLine + "Start: " + a.start;
                infoTextBox.Text += Environment.NewLine + "End: " + a.end;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ReportSelect reportSelect = new ReportSelect(username);
            reportSelect.Show();
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
