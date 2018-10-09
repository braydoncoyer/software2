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
using Software2.Forms;

namespace Software2
{
    public delegate void Callback(string username);
    public partial class Form1 : Form
    {
        public Callback cb;
        private string username;
        UserService _userSerivce = new UserService("");
        
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
                cb(usernameTextBox.Text);
                Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Show();
            }
        }
    }
}
