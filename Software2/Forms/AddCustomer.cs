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
    public delegate void Callback();
    public partial class AddCustomer : Form
    {
        private string username;
        public Callback addCustomerCB;
        public void setUsername(string username)
        {
            this.username = username;
            _customerService = new CustomerService(username);
        }
        CustomerService _customerService;
        AddressService _addressService = new AddressService();
        CityService _cityService = new CityService();
        CountryService _countryService = new CountryService();

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var findCountry = _countryService.findByName(countryTextbox.Text);
            if (findCountry == null)
            {
                _countryService.createCountry(countryTextbox.Text, username, DateTime.Now, DateTime.Now, username);
                findCountry = _countryService.findByName(countryTextbox.Text);
            }

            var findCity = _cityService.findByCityName(cityTextBox.Text, findCountry.countryId);
            if (findCity == null)
            {
                _cityService.createCity(cityTextBox.Text, findCountry.countryId, DateTime.Now, DateTime.Now, username);
                findCity = _cityService.findByCityName(cityTextBox.Text, findCountry.countryId);

            }
            _addressService.createAddress(address1TextBox.Text, address2TextBox.Text, findCity.cityId, zipCodeTextBox.Text, phoneNumberTextBox.Text);
            var findAddress = _addressService.findByAddressNameAndCityID(address1TextBox.Text, address2TextBox.Text, findCity.cityId);

            _customerService.CreateCustomer(nameTextBox.Text, true, username, DateTime.Now, DateTime.Now, username, findAddress.addressId);
            addCustomerCB();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            addCustomerCB();
        }
    }
}
