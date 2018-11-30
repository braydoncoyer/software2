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
        CustomerService _service;
        private enum editMode { add = 0, edit = 1 };
        int editmode;

        public EditCustomer()
        {
            InitializeComponent();
        }

        public EditCustomer(string username)
        {
            initClass(username);
            this.editmode = (int)editMode.add;
        }

        public EditCustomer(int customerID, string username)
        {
            this.customerID = customerID;
            initClass(username);
            this.editmode = (int)editMode.edit;
        }

        private void initClass(string username)
        {
            this.username = username;
            _service = new CustomerService(username);
            InitializeComponent();
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {

            if (editmode == (int)editMode.edit)
            {
                var customerDTO = _service.getCustomerByID(customerID);
                nameTextBox.Text = customerDTO.name;
                address1TextBox.Text = customerDTO.address1;
                address2TextBox.Text = customerDTO.address2;
                cityTextBox.Text = customerDTO.city;
                zipcodeTextBox.Text = customerDTO.zipcode;
                countryTextBox.Text = customerDTO.country;
                phoneTextBox.Text = customerDTO.phone;
            } else
            {
                titleLabel.Text = "Add Customer".ToUpper();
            }
            
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

            if (editmode == (int)editMode.edit)
            {
                customerDTO.id = customerID;
                _service.updateCustomer(customerDTO);
            }
            else
            {
                _service.addCustomer(customerDTO);
            }

            CustomerList _customerList = new CustomerList(this.username);
            _customerList.Show();
            this.Close();

        }
    }
}
