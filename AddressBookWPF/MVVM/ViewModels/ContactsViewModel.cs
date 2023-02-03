using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using AddressBookWPF.MVVM.Models;
using AddressBookWPF.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows;
using Newtonsoft.Json;
using System.Linq;

namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {


        private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contentAddressBook.json");

        [ObservableProperty]
        private string pageTitle = "Contacts";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();

        [ObservableProperty]
        private ContactModel selectedContact = null!;

        



        [RelayCommand]
        public void Remove()
        {
            string mb_message = "Are you sure you want to delete this contact?";
            string mb_title = "Delete contact";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage mb_icon = MessageBoxImage.Question;
            MessageBoxResult result;

            
            result = MessageBox.Show(mb_message, mb_title, buttons, mb_icon, MessageBoxResult.Yes);
            
            if (result == MessageBoxResult.Yes) 
            {
                ContactService.Remove(SelectedContact);
            }
            else { }
            
        }




        [RelayCommand]
        public void Update() 
        {
            string mb_message = "Are you sure you want to update the contact information?";
            string mb_title = "Update contact";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage mb_icon = MessageBoxImage.Question;
            MessageBoxResult result;


            result = MessageBox.Show(mb_message, mb_title, buttons, mb_icon, MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                ContactService.Update(SelectedContact);
            }
            else { }

        }




     


    }
}
