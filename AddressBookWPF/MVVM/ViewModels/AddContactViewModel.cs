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

namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
/*        private readonly FileService fileService;

        public AddContactViewModel()
        {
            fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contentAddressBook.json");
            contacts = fileService.Contacts();
        }*/


        [ObservableProperty]
        private string pageTitle = "Add Contact";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();

        [ObservableProperty]
        private string contact = string.Empty;

/*        [RelayCommand]
        private void Add()
        {
            ContactService.Add(new ContactModel { contact });
        }*/
    }   
}
