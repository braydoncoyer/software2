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
    public partial class CustomerList : Form
    {
        private string username;
        CustomerService _service;

        public CustomerList()
        {
            InitializeComponent();
        }

        public CustomerList(string username)
        {
            this.username = username;
            _service = new CustomerService(this.username);
            InitializeComponent();
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            var customers = new CustomerService(username).getCustomers();
            customerTable.DataSource = customers;
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            int selectedRow = customerTable.SelectedRows[0].Index;
            int customerID = Convert.ToInt32(customerTable.Rows[selectedRow].Cells[customerTable.ColumnCount-1].Value);
            EditCustomer editCustomerForm = new EditCustomer(customerID, username);
            editCustomerForm.Show();

            this.Close();
            
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            EditCustomer editCustomerForm = new EditCustomer(username);
            editCustomerForm.Show();
            this.Close();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            int selectedRow = customerTable.SelectedRows[0].Index;
            int customerID = Convert.ToInt32(customerTable.Rows[selectedRow].Cells[customerTable.ColumnCount - 1].Value);
            _service.deleteCustomer(customerID);

            // TODO: Figure out why form is not refreshing to see new udpated data.
            this.Refresh();
        }
    }
}
