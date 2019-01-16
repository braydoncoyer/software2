using Software2.DTO;
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
            appointmentIDTextBox.Hide();
            setCustomerCombo();
            setDateFormats();
            setTypeCombo();
            if (editmode == (int)editMode.edit)
            {
                var appointment = _appointmentService.getAppointmentDTOByID(id);
                setElements(appointment);
            }
            else
            {
                titleLabel.Text = "Add Appointment".ToUpper();
            }
        }

        private void setTypeCombo()
        {
            //todo: alphabet
            typeComboBox.DataSource = new string[] { "Meeting", "Follow Up", "Lunch", "Other" };
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

        private void setElements(appointmentDTO appointment)
        {
            nameTextBox.Text = appointment.title;
            customerComboBox.SelectedValue = appointment.customerId;
            typeComboBox.Text = appointment.type;
            contactTextBox.Text = appointment.contact;
            locationTextBox.Text = appointment.location;
            URLTextBox.Text = appointment.url;
            descriptionTextBox.Text = appointment.description;
            startDatePicker.Value = appointment.start;
            endDatePicker.Value = appointment.end;
            appointmentIDTextBox.Text = appointment.appointmentID.ToString();
            appointmentIDTextBox.Visible = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(editmode == (int)editMode.edit)
            {
                // Update
                var updatedAppointment = createAppointmentDTO();
                errorLabel.Text = "";
                errorLabel.Hide();
                try
                {
                    validateAppointment(updatedAppointment, OPENTIME, CLOSETIME);
                    _appointmentService.updateAppointmentDTO(updatedAppointment);

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
                var appointmentToCreate = createAppointmentDTO();
                try
                {
                    validateAppointment(appointmentToCreate, OPENTIME, CLOSETIME);
                    _appointmentService.addAppointmentDTO(appointmentToCreate);

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

        private void validateAppointment(appointmentDTO _appointmentDTO, int opened, int closed)
        {
            validateFormFields();
            validateBusinessHours(_appointmentDTO, opened, closed);
            validateAppointmentTimes(_appointmentDTO);
            validateNoOverlappingAppointments(_appointmentDTO);
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

        private void validateNoOverlappingAppointments(appointmentDTO _appointmentDTO)
        {
            //Make Sure No Overlapping Schedules
            var appointments = _appointmentService.getAllAppointmentDatesForAUser(this.username);
            // Ensure that we get a list of appointments that EXCLUDES the current appointment if editing.
            appointments = appointments.Where(a => a.id != _appointmentDTO.appointmentID).ToList();

            foreach (AppointmentDate a in appointments)
            {

                if (isDateBetween(a.Start, a.End, _appointmentDTO.start) || isDateBetween(a.Start, a.End, _appointmentDTO.end))
                {
                    throw new appointmentException("The date you've selected falls between a preexisting appointment");
                }
            }
        }

        private void validateAppointmentTimes(appointmentDTO _appointmentDTO)
        {
            //Ensure that start hour is before the end hour
            if (_appointmentDTO.start.Hour > _appointmentDTO.end.Hour)
            {
                throw new appointmentException("The starting time must be before the ending time");
            }

            //Ensure that days and years are valid

            if (_appointmentDTO.start.Day > _appointmentDTO.end.Day || _appointmentDTO.start.Year > _appointmentDTO.end.Year)
            {
                throw new appointmentException("You cannot save appointments that start after the end date you've selected");
            }
        }

        private void validateBusinessHours(appointmentDTO _appointmentDTO, int opened, int closed)
        {
            // Ensure during business hours
            if (_appointmentDTO.start.Hour < opened || _appointmentDTO.end.Hour < opened)
            {
                throw new appointmentException("Must be between normal business hours");
            }
            if (_appointmentDTO.start.Hour > closed || _appointmentDTO.end.Hour > closed)
            {
                throw new appointmentException("Must be between normal business hours");
            }
        }

        private bool isDateBetween(DateTime date1, DateTime date2, DateTime testDate)
        {
            return testDate.Ticks > date1.Ticks && testDate.Ticks < date2.Ticks;
        }

        private appointmentDTO createAppointmentDTO()
        {
            var appointmentDTO = new appointmentDTO();

            if (editmode == (int)editMode.edit)
            {
                appointmentDTO.appointmentID = Convert.ToInt32(appointmentIDTextBox.Text);
            }
            
            appointmentDTO.customerId = (int)customerComboBox.SelectedValue;
            appointmentDTO.title = nameTextBox.Text;
            appointmentDTO.description = descriptionTextBox.Text;
            appointmentDTO.location = locationTextBox.Text;
            appointmentDTO.contact = contactTextBox.Text;
            appointmentDTO.url = URLTextBox.Text;
            appointmentDTO.start = startDatePicker.Value;
            appointmentDTO.end = endDatePicker.Value;
            appointmentDTO.type = typeComboBox.Text;
            return appointmentDTO;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AppointmentList appointmentList = new AppointmentList(this.username);
            appointmentList.Show();
            this.Close();
        }
    }
}
