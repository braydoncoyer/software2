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
using System.IO;

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
                writeToUserLoginFile();
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

        private void writeToUserLoginFile()
        {
            string fileName = string.Format("{0}/UserLoginRecord.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            StreamWriter objWriter = File.AppendText(fileName);

            DateTime loginTime = DateTime.Now;

            objWriter.WriteLine(String.Format("{0} logged in on {1} at {2}", usernameTextBox.Text, loginTime.ToShortDateString(), loginTime.ToShortTimeString()));
            objWriter.Close();
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
