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
using System.Globalization;

namespace Software2
{
    public partial class Form1 : Form
    {
        UserService _userSerivce = new UserService();

        public Form1()
        {
            InitializeComponent();
            errorLabel.Text = "";
            passwordTextBox.PasswordChar = '*' ;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            try
            {
                _userSerivce.login(usernameTextBox.Text, passwordTextBox.Text);
                Main form = new Main(usernameTextBox.Text);
                this.Hide();
                form.Show();
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Show();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
