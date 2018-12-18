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

namespace Software2.Forms
{
    public partial class Appointments : Form
    {
        CustomerService _customerService;
        UserService _userService = new UserService();
        AppointmentService _appointmentService = new AppointmentService();
        private string username;

        public Appointments()
        {
            InitializeComponent();
        }

        public Appointments(string username)
        {
            this.username = username;
            _customerService = new CustomerService(this.username);
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Appointments_Load(object sender, EventArgs e)
        {

            startDatePicker.Format = DateTimePickerFormat.Custom;
            startDatePicker.CustomFormat = "MM/dd/yyyy hh:mm";
            endDatePicker.Format = DateTimePickerFormat.Custom;
            endDatePicker.CustomFormat = "MM/dd/yyyy hh:mm";
            var customerList = _customerService.getCustomers();
            
            customerComboBox.ValueMember = "customerId";
            customerComboBox.DisplayMember = "customerName";
            customerComboBox.DataSource = customerList;

            var id = 1;
            var appointment = _appointmentService.getAppointmentByID(id);
            nameTextBox.Text = appointment.title;
            customerComboBox.SelectedIndex = appointment.customerId;
            contactTextBox.Text = appointment.contact;
            locationTextBox.Text = appointment.location;
            URLTextBox.Text = appointment.url;
            descriptionTextBox.Text = appointment.description;
            startDatePicker.Value = appointment.start;
            endDatePicker.Value = appointment.end;
        }
    }
}
