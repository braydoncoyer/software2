using Software2.Models;
using Software2.Models.Exceptions;
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
        private CustomerAggregate customer;
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

        private void add() {
            customer = new CustomerAggregate();
            UpdateAddressFields();
            UpdateCustomerFields();
            //validateFields();

            var addressId = UpdateAddress();

            customer.AddressId = addressId;
            _customerService.Add(customer);
        }

        private void UpdateAddressFields()
        {
            var address1 = address1TextBox.Text;
            var address2 = address2TextBox.Text;
            var postalCode = zipCodeTextBox.Text;
            var name = nameTextBox.Text;
            var city = cityTextBox.Text;
            var country = countryTextbox.Text;
            var phone = phoneNumberTextBox.Text;
            customer.Address1 = address1;
            customer.Address2 = address2;
            customer.Country = country;
            customer.City = city;
            customer.PostalCode = postalCode;
            customer.Phone = phone;
        }

        private void UpdateCustomerFields()
        {
            customer.CustomerName = nameTextBox.Text;
        }

        private int UpdateAddress()
        {
            address address;
            var addressAggregate = new AddressAggregate()
            {
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                PostalCode = customer.PostalCode,
                CountryName = customer.Country,
                CityName = customer.City,
                Phone = customer.Phone
            };

            try
            {
                address = _addressService.FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);
                addressAggregate.CityId = address.cityId;
                addressAggregate.AddressId = address.addressId;
                _addressService.UpdateAddress(addressAggregate);
            }
            catch (NotFoundException e)
            {
                _addressService.addNewAddress(addressAggregate);
                address = _addressService.FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);
            }

            return address.addressId;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            add();


            //var findCountry = _countryService.findByName(countryTextbox.Text);
            //if (findCountry == null)
            //{
            //    _countryService.createCountry(countryTextbox.Text, username, DateTime.Now.ToUniversalTime(), DateTime.Now.ToUniversalTime(), username);
            //    findCountry = _countryService.findByName(countryTextbox.Text);
            //}

            //var findCity = _cityService.findByCityName(cityTextBox.Text, findCountry.countryId);
            //if (findCity == null)
            //{
            //    _cityService.createCity(cityTextBox.Text, findCountry.countryId, DateTime.Now.ToUniversalTime(), DateTime.Now.ToUniversalTime(), username);
            //    findCity = _cityService.findByCityName(cityTextBox.Text, findCountry.countryId);

            //}
            //_addressService.createAddress(address1TextBox.Text, address2TextBox.Text, findCity.cityId, zipCodeTextBox.Text, phoneNumberTextBox.Text);
            //var findAddress = _addressService.findByAddressNameAndCityID(address1TextBox.Text, address2TextBox.Text, findCity.cityId);

            //_customerService.CreateCustomer(nameTextBox.Text, true, username, DateTime.Now.ToUniversalTime(), DateTime.Now.ToUniversalTime(), username, findAddress.addressId);
            //addCustomerCB();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            addCustomerCB();
        }
    }
}
