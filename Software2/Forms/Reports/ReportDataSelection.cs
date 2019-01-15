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

namespace Software2.Forms.Reports
{
    public partial class ReportDataSelection : Form
    {
        string username;
        CustomerService _customerService;
        UserService _userService;
        private enum formMode { consultant = 0, appointment = 1, customer = 2 };
        int formmode;

        public ReportDataSelection()
        {
            InitializeComponent();
        }

        public ReportDataSelection(string username, int mode)
        {
            this.username = username;
            _customerService = new CustomerService(this.username);
            _userService = new UserService();
            setFormMode(mode);
            InitializeComponent();
        }

        private void initializeElements()
        {
            string format = "MM/yyyy";
            startDatePicker.CustomFormat = format;
            startDatePicker.Hide();

            typeComboBox.Hide();
            
            

            if (formmode == (int)formMode.consultant || formmode == (int)formMode.customer)
            {
                typeComboBox.Show();

                if (formmode == (int)formMode.consultant)
                {
                    setComboBoxValuesToUsers();
                }

                if (formmode == (int)formMode.customer)
                {
                    setComboBoxValuesToCustomer();
                }
            }
            else
            {
                startDatePicker.Show();
            }

        }

        private void setComboBoxValuesToCustomer()
        {
            var customerList = _customerService.getCustomers();
            typeComboBox.ValueMember = "customerId";
            typeComboBox.DisplayMember = "customerName";
            typeComboBox.DataSource = customerList;
        }

        private void setComboBoxValuesToUsers()
        {
            var userList = _userService.getUsers();
            typeComboBox.ValueMember = "userId";
            typeComboBox.DisplayMember = "userName";
            typeComboBox.DataSource = userList;
        }

        private void setFormMode(int mode)
        {
            switch (mode)
            {
                case 0:
                    this.formmode = (int)formMode.consultant;
                    break;

                case 1:
                    this.formmode = (int)formMode.appointment;
                    break;

                case 2:
                    this.formmode = (int)formMode.customer;
                    break;

                default:
                    break;
            }
        }

        private void ReportDataSelection_Load(object sender, EventArgs e)
        {
            initializeElements();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            ReportForm reportForm;

            if (formmode == (int)formMode.consultant || formmode == (int)formMode.customer)
            {
                reportForm = new ReportForm(username, formmode, (int)typeComboBox.SelectedValue);
            }
            else
            {
                reportForm = new ReportForm(username, formmode, startDatePicker.Value.Month);
            }

            reportForm.Show();
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ReportSelect reportSelect = new ReportSelect(username);
            reportSelect.Show();
            this.Close();
        }
    }
}
