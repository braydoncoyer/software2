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
        AppointmentService _appointmentService;
        private string username;
        int id = 1;

        public Appointments()
        {
            InitializeComponent();
        }

        public Appointments(string username)
        {
            this.username = username;
            _customerService = new CustomerService(this.username);
            _appointmentService = new AppointmentService(this.username);
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            
            var appointment = _appointmentService.getAppointmentByID(id);

            setCustomerCombo();
            setDateFormats();
            setElements(appointment);

        }

        private void setCustomerCombo()
        {
            var customerList = _customerService.getCustomers();
            customerComboBox.ValueMember = "customerId";
            customerComboBox.DisplayMember = "customerName";
            customerComboBox.DataSource = customerList;
        }

        private void setDateFormats()
        {
            string format = "MM/dd/yyyy hh:mm";
            startDatePicker.CustomFormat = format;
            endDatePicker.CustomFormat = format;
        }

        private void setElements(appointment appointment)
        {
            nameTextBox.Text = appointment.title;
            customerComboBox.SelectedIndex = appointment.customerId;
            contactTextBox.Text = appointment.contact;
            locationTextBox.Text = appointment.location;
            URLTextBox.Text = appointment.url;
            descriptionTextBox.Text = appointment.description;
            startDatePicker.Value = appointment.start;
            endDatePicker.Value = appointment.end;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var updatedAppointment = createAppointment();
            _appointmentService.updateAppointment(updatedAppointment);
        }

        private appointment createAppointment()
        {
            var appointment = _appointmentService.getAppointmentByID(id);
            appointment.customerId = (int)customerComboBox.SelectedValue;
            appointment.title = nameTextBox.Text;
            appointment.description = descriptionTextBox.Text;
            appointment.location = locationTextBox.Text;
            appointment.contact = contactTextBox.Text;
            appointment.url = URLTextBox.Text;
            appointment.start = startDatePicker.Value;
            appointment.end = endDatePicker.Value;
            return appointment;
        }
    }
}
