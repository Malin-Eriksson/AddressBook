using AddressBookWPF.MVVM.Models;
using AddressBookWPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    public partial class ContactsView : UserControl
    {
       

        public ContactsView()
        {
            InitializeComponent();

        }

        private void CancelUpdate_Click(object sender, RoutedEventArgs e)
        {
            ContactService.CancelUpdate();
            

        }
    }

   

    }
