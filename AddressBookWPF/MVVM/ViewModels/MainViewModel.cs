using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel = new ContactsViewModel();

        //Navigation

        [RelayCommand]
        private void GoToAddContact() => CurrentViewModel = new AddContactViewModel();
        

        [RelayCommand]
        private void GoToContacts() => CurrentViewModel = new ContactsViewModel();
     

        public MainViewModel()
        {
            CurrentViewModel = new ContactsViewModel();
        }
    }
}
