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
        CustomerService _service = new CustomerService();

        public EditCustomer()
        {
            InitializeComponent();
        }

        public EditCustomer(int customerID, string username)
        {
            this.username = username;
            this.customerID = customerID;
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
            customerDTO.id = customerID;
            //customerDTO.address1 = address1TextBox.Text;
            _service.updateCustomer(customerDTO, username);

        }
    }
}
