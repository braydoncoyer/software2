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
        CityService _cityService = new CityService();

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _customerService.CreateCustomer(nameTextBox.Text, true, "braydon", DateTime.Now, DateTime.Now, "braydon");
            _cityService.createCity(cityTextBox.Text, "1", DateTime.Now, DateTime.Now, "braydon");
            _addressService.createAddress(address1TextBox.Text, address2TextBox.Text, "1", zipCodeTextBox.Text, phoneNumberTextBox.Text);
        }
    }
}
