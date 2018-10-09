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
        private AddCustomer addCustomer = new AddCustomer();
        private bool authenticated = false;
        public Home()
        {
            InitializeComponent();
            if (!this.authenticated)
            {
                loginForm.cb = (username => {
                    setUsername(username);
                    loginForm.Close();
                });

                loginForm.Show();
                this.Hide();
            }
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
    }
}
