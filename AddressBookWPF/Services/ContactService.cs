using AddressBookWPF.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWPF.Services
{
    public static class ContactService
    {



        private static ObservableCollection<ContactModel> contacts;
        private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contentAddressBook.json");


        static ContactService()
        {
            try
            {
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(fileService.ReadFromFile())!;
            }
            catch { contacts = new ObservableCollection<ContactModel>(); }
            
        }
      

        public static void Add(ContactModel model)
        {
            if (contacts != null)
            {
                contacts.Add(model);
                fileService.SaveFile(JsonConvert.SerializeObject(contacts));
            }
            else { 
                contacts = new ObservableCollection<ContactModel>();
                contacts.Add(model);
                fileService.SaveFile(JsonConvert.SerializeObject(contacts));
            }
        }


        public static void Remove(ContactModel model) 
        {
            contacts.Remove(model);
            fileService.SaveFile(JsonConvert.SerializeObject(contacts));
        }




        public static void Update(ContactModel model)
        {
            fileService.SaveFile(JsonConvert.SerializeObject(contacts));
        }


        public static void CancelUpdate()
        {
            contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(fileService.ReadFromFile())!;
            // Saknar funktion för att ladda om huvudsidan...
        }

        public static ObservableCollection<ContactModel> Contacts()
        {
            return contacts;
        }
    }
}
