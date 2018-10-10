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
    public partial class Home : Form
    {
        private string username;
        private Form1 loginForm = new Form1();
        private CustomerList customerList = new CustomerList();
        private AddCustomer addCustomer = new AddCustomer();
        private bool authenticated = false;
        public Home()
        {
            InitializeComponent();
            addCustomerButton.Hide();
            createAppointmentButton.Hide();
            // Why is this callback not working?
            addCustomer.addCustomerCB = () => {
                addCustomer.Hide();
                this.Show();
            };
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void setUsername(string username)
        {
            addCustomer.setUsername(username);
            this.authenticated = true;
            this.username = username;
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (!this.authenticated)
            {

                loginForm.Show();
                this.Hide();

                loginForm.cb = (username =>
                {
                    setUsername(username);
                    loginForm.Close();
                    this.Show();
                    signInButton.Hide();
                    addCustomerButton.Show();
                    createAppointmentButton.Show();
                });
            }
           
            
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            customerList.Show();
            //addCustomer.Show();
            this.Hide();
        }
    }
}
