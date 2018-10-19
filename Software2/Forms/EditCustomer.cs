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
    public partial class EditCustomer : Form
    {
        CustomerService _customerService;
        AddressService _addressService = new AddressService();
        CityService _cityService = new CityService();
        CountryService _countryService = new CountryService();
        private customer updatedCustomer;
        private address updatedAddress;
        private city updatedCity;
        private country updatedCountry;
        public EditCustomer(customer customer, address address, city city, country country)
        {
            errorLabel.Hide();
            InitializeComponent();
            updatedCustomer = customer;
            updatedAddress = address;
            updatedCity = city;
            updatedCountry = country;

            nameTextBox.Text = customer.customerName;
            address1TextBox.Text = address.address1;
            address2TextBox.Text = address.address2;
            cityTextBox.Text = city.city1;
            countryTextbox.Text = country.country1;
            zipCodeTextBox.Text = address.postalCode;
            phoneNumberTextBox.Text = address.phone;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            if(nameTextBox.Text != null && address1TextBox.Text != null & address2TextBox.Text != null 
                && cityTextBox.Text != null && countryTextbox.Text != null && 
                zipCodeTextBox.Text != null && phoneNumberTextBox.Text != null )
            {
                errorLabel.Hide();
                updatedCustomer.customerName = nameTextBox.Text;
                updatedAddress.address1 = address1TextBox.Text;
                updatedAddress.address2 = address2TextBox.Text;
                updatedCity.city1 = cityTextBox.Text;
                updatedCountry.country1 = countryTextbox.Text;
                updatedAddress.postalCode = zipCodeTextBox.Text;
                updatedAddress.phone = phoneNumberTextBox.Text;

                _customerService.updateCustomer(updatedCustomer);
                _addressService.updateAddress(updatedAddress);
                _cityService.updateCity(updatedCity);
                _countryService.updateCountry(updatedCountry);
            }
            else
            {
                errorLabel.Text = "Please fill in all input forms.";
                errorLabel.Show();
            }
            
        }
    }
}
