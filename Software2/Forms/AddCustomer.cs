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
        CustomerService _customerService = new CustomerService();
        AddressService _addressService = new AddressService();

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //var customer = new customer();
            //customer.customerName = nameTextBox.Text;
            //var address = _addressService.createAddress(address1TextBox.Text, address2TextBox.Text, "1", zipCodeTextBox.Text, phoneNumberTextBox.Text);
            //customer.active = true;
            //customer.createdBy = "braydon";
            //customer.createDate = DateTime.Now;
            //customer.lastUpdate = DateTime.Now;
            //customer.lastUpdateBy = "braydon";
            //_customerService.CreateCustomer(customer);
            //Console.WriteLine("CreatedCustomer");

            var customer = _customerService.findCustomerById(13);
            Console.WriteLine(customer.customerName);
        }
    }
}
