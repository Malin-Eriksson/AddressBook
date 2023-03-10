using AddressBookWPF.MVVM.Models;
using AddressBookWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AddressBookWPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddContactView.xaml
    /// </summary>
    public partial class AddContactView : UserControl
    {
        public AddContactView()
        {
            InitializeComponent();
        }





        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            ContactService.Add( new ContactModel {
                FirstName = tb_firstName.Text, 
                LastName = tb_lastName.Text,
                Email = tb_email.Text,
                PhoneNumber = tb_phoneNumber.Text,
                StreetAddress = tb_streetAddress.Text,
                PostalCode = tb_postalCode.Text,
                City = tb_city.Text
            });

            ClearForm();

        }

        private void ClearForm()
        {

            tb_firstName.Text= string.Empty;
            tb_lastName.Text= string.Empty;
            tb_email.Text= string.Empty;
            tb_phoneNumber.Text= string.Empty;
            tb_streetAddress.Text= string.Empty;
            tb_postalCode.Text= string.Empty;
            tb_city.Text= string.Empty; 
        }
    }
}
