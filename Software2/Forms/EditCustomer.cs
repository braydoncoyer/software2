using Software2.DTO;
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
    public partial class EditCustomer : Form
    {
        private int customerID;
        private string username;
        private Form previousForm;
        CustomerService _service;

        public EditCustomer()
        {
            InitializeComponent();
        }

        public EditCustomer(int customerID, string username, Form previousForm)
        {
            this.username = username;
            this.customerID = customerID;
            this.previousForm = previousForm;
            _service = new CustomerService(username);
            InitializeComponent();
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            var customerDTO = _service.getCustomerByID(customerID);
            nameTextBox.Text = customerDTO.name;
            address1TextBox.Text = customerDTO.address1;
            address2TextBox.Text = customerDTO.address2;
            cityTextBox.Text = customerDTO.city;
            zipcodeTextBox.Text = customerDTO.zipcode;
            countryTextBox.Text = customerDTO.country;
            phoneTextBox.Text = customerDTO.phone;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var customerDTO = new customerDTO();
            customerDTO.name = nameTextBox.Text;
            customerDTO.address1 = address1TextBox.Text;
            customerDTO.address2 = address2TextBox.Text;
            customerDTO.city = cityTextBox.Text;
            customerDTO.country = countryTextBox.Text;
            customerDTO.zipcode = zipcodeTextBox.Text;
            customerDTO.phone = phoneTextBox.Text;
            customerDTO.id = customerID;
            _service.updateCustomer(customerDTO);
            this.Hide();
            this.previousForm.Show();

        }
    }
}
