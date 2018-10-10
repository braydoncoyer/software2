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


        public CustomerList()
        {
            InitializeComponent();
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
    }
}
