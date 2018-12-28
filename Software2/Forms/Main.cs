﻿using Software2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
