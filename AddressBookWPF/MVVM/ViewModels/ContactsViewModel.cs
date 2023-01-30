using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using AddressBookWPF.MVVM.Models;
using AddressBookWPF.Services;
using CommunityToolkit.Mvvm.Input;
using System;

namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
/*        private readonly FileService fileService;
        public ContactsViewModel()
        {
            fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contentAddressBook.json");
            contacts = fileService.Contacts();
        }*/

        [ObservableProperty]
        private string pageTitle = "Contacts";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();

        [ObservableProperty]
        private ContactModel selectedContact = null!;


        [RelayCommand]
        public void Remove()
        {
            ContactService.Remove(SelectedContact);
        }
  
    }
}
