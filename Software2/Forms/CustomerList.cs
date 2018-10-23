using Software2.Models;
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
    public partial class CustomerList : Form
    {
        CustomerService _customerService = new CustomerService("braydon");
        private BindingSource customerBindingSource = new BindingSource();
        private List<customer> customers;
        public Callback cancelCB;
        private EditCustomer editCustomer;
        private AddCustomer addCustomer;


        public CustomerList()
        {
            InitializeComponent();
            addCustomer = new AddCustomer();
            //editCustomer = new EditCustomer();
            customers = _customerService.FindAllCustomers();
            customerBindingSource.DataSource = customers.Select(c => new
            CustomerRow
            {
                Id = c.customerId,
                Name = c.customerName,
                AddressId = c.addressId,
                Created = c.createDate,
                Updated = c.lastUpdate
            }).ToList();
            customerGridView.DataSource = customerBindingSource;
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {


        }

        private customer GetItemFromSelectedRow(DataGridView gridView)
        {
            if (gridView.SelectedRows.Count <= 0) return null;
            if (gridView.SelectedRows.Count > 1) { }
            var selectedRow = gridView.SelectedRows[0];
            var customerRow = selectedRow.DataBoundItem as CustomerRow;
            if (customerRow == null)
                return null;
            int id = customerRow.Id;
            return customers.FirstOrDefault(p => p.customerId == id);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void editCustomerButton_Click_1(object sender, EventArgs e)
        {
            var customerFromRow = GetItemFromSelectedRow(customerGridView);
            if (customerFromRow == null)
            {
                return;
            }
            //editCustomer = new EditCustomer(customerFromRow, )
            editCustomer.Show();
            this.Close();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            addCustomer.Show();
        }
    }
}
