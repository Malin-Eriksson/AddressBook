using AddressBookWPF.MVVM.Models;
using AddressBookWPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class UpdateContactViewModel : ObservableObject
    {


        [ObservableProperty]
        private string pageTitle = "Update Contact";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();

        [ObservableProperty]
        private string contact = string.Empty;

        
    }
}
