using AddressBookWPF.MVVM.Models;
using AddressBookWPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {



        [ObservableProperty]
        private string pageTitle = "Add Contact";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();

        [ObservableProperty]
        private string contact = string.Empty;

        [ObservableProperty]
        private ContactModel contactModel = new ContactModel();
        

        [RelayCommand]
        public void Add()
        {

            ContactService.Add(contactModel);
            contactModel = new ContactModel();
        }
    }   
}
