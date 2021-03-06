﻿using Software2.DTO;
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
    public partial class AppointmentList : Form
    {
        private string username;
        AppointmentService _service;
        public AppointmentList()
        {
            InitializeComponent();
        }

        public AppointmentList(string username)
        {
            this.username = username;
            _service = new AppointmentService(this.username);
            InitializeComponent();
        }

        private void AppointmentList_Load(object sender, EventArgs e)
        {
            string[] comboOptions = new string[] { "Month", "Week" };
            viewByComboBox.DataSource = comboOptions;
            viewByComboBox.Text = "Month";
            this.viewByComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            populateAppointmentDataGrid();
        }

        private void populateAppointmentDataGrid()
        {
            List<appointmentDTO> appointments = new List<appointmentDTO>();
            if(String.Equals(viewByComboBox.Text, "Month"))
            {
                appointments = new AppointmentService(username).getAppointmentDTOsByMonth(DateTime.Now.Month);
            } else if(String.Equals(viewByComboBox.Text, "Week"))
            {
                appointments = new AppointmentService(username).getAppointmentDTOsByWeek();
            }

            string dateFormat = "MM/dd/yyyy";
            appointmentTable.DataSource = appointments;
            appointmentTable.Columns["start"].DefaultCellStyle.Format = dateFormat;
            appointmentTable.Columns["end"].DefaultCellStyle.Format = dateFormat;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            int selectedRow = appointmentTable.SelectedRows[0].Index;
            int appointmentID = Convert.ToInt32(appointmentTable.Rows[selectedRow].Cells[7].Value);
            Appointments editAppointment = new Appointments(appointmentID, username);
            editAppointment.Show();

            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Appointments addAppointment = new Appointments(this.username);
            addAppointment.Show();
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int selectedRow = appointmentTable.SelectedRows[0].Index;
            int appointmentID = Convert.ToInt32(appointmentTable.Rows[selectedRow].Cells[7].Value);
            _service.deleteAppointment(appointmentID);
            populateAppointmentDataGrid();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main(username);
            mainForm.Show();
            this.Close();
        }

        private void viewByButton_Click(object sender, EventArgs e)
        {
            populateAppointmentDataGrid();
            Console.WriteLine(viewByComboBox.SelectedValue);
        }
    }
}
