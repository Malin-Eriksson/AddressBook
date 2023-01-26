using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        //Navigation
        [RelayCommand]
        private void GoToAddTodo() => CurrentViewModel = new AddTodoViewModel();


        [RelayCommand]
        private void GoToTodos () => CurrentViewModel = new TodosViewModel();

        

        public MainViewModel()
        {
            CurrentViewModel = new TodosViewModel();
        }
    }
}
