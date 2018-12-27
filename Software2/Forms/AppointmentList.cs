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
    public partial class AppointmentList : Form
    {

        private string username;
        AppointmentService _service;

        public AppointmentList()
        {
            InitializeComponent();
        }

        public AppointmentList(string username)
        {
            this.username = username;
            _service = new AppointmentService(this.username);
            InitializeComponent();
        }

        private void AppointmentList_Load(object sender, EventArgs e)
        {

        }
    }
}
