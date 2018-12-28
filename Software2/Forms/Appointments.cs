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
        int id;
        private enum editMode { add = 0, edit = 1 };
        int editmode;

        public Appointments(string username)
        {
            initClass(username);
            this.editmode = (int)editMode.add;
        }

        public Appointments(int id, string username)
        {
            this.id = id;
            initClass(username);
            this.editmode = (int)editMode.edit;
        }

        private void initClass(string username)
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
            errorLabel.Hide();
            setCustomerCombo();
            setDateFormats();
            if (editmode == (int)editMode.edit)
            {
                var appointment = _appointmentService.getAppointmentByID(id);
                setElements(appointment);
            }
            else
            {
                titleLabel.Text = "Add Appointment".ToUpper();
            }
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
            string format = "MM/dd/yyyy hh:mm tt";
            startDatePicker.CustomFormat = format;
            endDatePicker.CustomFormat = format;
        }

        private void setElements(appointment appointment)
        {
            nameTextBox.Text = appointment.title;
            customerComboBox.SelectedValue = appointment.customerId;
            contactTextBox.Text = appointment.contact;
            locationTextBox.Text = appointment.location;
            URLTextBox.Text = appointment.url;
            descriptionTextBox.Text = appointment.description;
            startDatePicker.Value = appointment.start;
            endDatePicker.Value = appointment.end;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(editmode == (int)editMode.edit)
            {
                // Update
                var updatedAppointment = createAppointment();
                errorLabel.Text = "";
                errorLabel.Hide();
                try
                {
                    validateAppointment(updatedAppointment);
                    _appointmentService.updateAppointment(updatedAppointment);

                    AppointmentList appointmentList = new AppointmentList(this.username);
                    appointmentList.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    errorLabel.Text = ex.Message;
                    errorLabel.Show();
                }
            } else
            {
                //Add
                var appointmentToCreate = createAppointment();
                try
                {
                    validateAppointment(appointmentToCreate);
                    _appointmentService.addAppointment(appointmentToCreate);

                    AppointmentList appointmentList = new AppointmentList(this.username);
                    appointmentList.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    errorLabel.Text = ex.Message;
                    errorLabel.Show();
                }
            }
            
        }

        private void validateAppointment(appointment appointment)
        {

            int OPENED = 9;
            int CLOSED = 17;
            // Ensure during business hours
            if (appointment.start.Hour < OPENED || appointment.end.Hour < OPENED)
            {
                throw new Exception("Must be between normal business hours");
            }
            if (appointment.start.Hour > CLOSED || appointment.end.Hour > CLOSED)
            {
                throw new Exception("Must be between normal business hours");
            }
        }

        private appointment createAppointment()
        {
            var appointment = new appointment();

            if (editmode == (int)editMode.edit)
            {
                appointment = _appointmentService.getAppointmentByID(id);
            }
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main(this.username);
            mainForm.Show();
            this.Close();
        }
    }
}
