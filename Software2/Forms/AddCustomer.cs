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
    public partial class AddCustomer : Form
    {
        UserService _userSerivce = new UserService();

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var customer = new customer();
            Random rnd = new Random();
            customer.customerName = nameTextBox.Text;
            customer.customerId = rnd.Next(2, 900);
            customer.addressId = address1TextBox.Text;
            customer.active = true;
            customer.createdBy = "braydon";
            customer.createDate = DateTime.Now;
            customer.lastUpdate = DateTime.Now;
            customer.lastUpdateBy = "braydon";
            _userSerivce.;
        }
    }
}
