using Software2.Exceptions;
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
        const int OPENTIME = 9;
        const int CLOSETIME = 17;

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
                    validateAppointment(updatedAppointment, OPENTIME, CLOSETIME);
                    _appointmentService.updateAppointment(updatedAppointment);

                    AppointmentList appointmentList = new AppointmentList(this.username);
                    appointmentList.Show();
                    this.Close();
                }
                catch (appointmentException ex)
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
                    validateAppointment(appointmentToCreate, OPENTIME, CLOSETIME);
                    _appointmentService.addAppointment(appointmentToCreate);

                    AppointmentList appointmentList = new AppointmentList(this.username);
                    appointmentList.Show();
                    this.Close();
                }
                catch (appointmentException ex)
                {
                    errorLabel.Text = ex.Message;
                    errorLabel.Show();
                }
            }
            
        }

        private void validateAppointment(appointment appointment, int opened, int closed)
        {
            validateFormFields();
            validateBusinessHours(appointment, opened, closed);
            validateAppointmentTimes(appointment);
            validateNoOverlappingAppointments(appointment);
        }

        private void validateFormFields()
        {
         if(string.IsNullOrWhiteSpace(nameTextBox.Text) ||
               string.IsNullOrWhiteSpace(contactTextBox.Text) ||
               string.IsNullOrWhiteSpace(locationTextBox.Text) ||
               string.IsNullOrWhiteSpace(URLTextBox.Text) ||
               string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                throw new appointmentException("Please check all required fields to ensure they are valid.");
            }
        }

        private void validateNoOverlappingAppointments(appointment appointment)
        {
            //Make Sure No Overlapping Schedules
            var appointments = _appointmentService.getAllAppointmentDatesForAUser(this.username);
            // Ensure that we get a list of appointments that EXCLUDES the current appointment if editing.
            appointments = appointments.Where(a => a.id != appointment.appointmentId).ToList();

            foreach (AppointmentDate a in appointments)
            {

                if (isDateBetween(a.Start, a.End, appointment.start) || isDateBetween(a.Start, a.End, appointment.end))
                {
                    throw new appointmentException("The date you've selected falls between a preexisting appointment");
                }
            }
        }

        private void validateAppointmentTimes(appointment appointment)
        {
            //Ensure that start hour is before the end hour
            if (appointment.start.Hour > appointment.end.Hour)
            {
                throw new appointmentException("The starting time must be before the ending time");
            }

            //Ensure that days and years are valid

            if (appointment.start.Day > appointment.end.Day || appointment.start.Year > appointment.end.Year)
            {
                throw new appointmentException("You cannot save appointments that start after the end date you've selected");
            }
        }

        private void validateBusinessHours(appointment appointment, int opened, int closed)
        {
            // Ensure during business hours
            if (appointment.start.Hour < opened || appointment.end.Hour < opened)
            {
                throw new appointmentException("Must be between normal business hours");
            }
            if (appointment.start.Hour > closed || appointment.end.Hour > closed)
            {
                throw new appointmentException("Must be between normal business hours");
            }
        }

        private bool isDateBetween(DateTime date1, DateTime date2, DateTime testDate)
        {
            return testDate.Ticks > date1.Ticks && testDate.Ticks < date2.Ticks;
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
            AppointmentList appointmentList = new AppointmentList(this.username);
            appointmentList.Show();
            this.Close();
        }
    }
}
