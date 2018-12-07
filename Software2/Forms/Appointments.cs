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
            var customerList = _customerService.getCustomers();
            
            customerComboBox.ValueMember = "customerId";
            customerComboBox.DisplayMember = "customerName";
            customerComboBox.DataSource = customerList;

            var userList = _userService.getUsers();

            userComboBox.ValueMember = "userId";
            userComboBox.DisplayMember = "userName";
            userComboBox.DataSource = userList;
        }
    }
}
