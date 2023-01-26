using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook_Classes.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adressbok_assignment.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        [RelayCommand]
        private void GoToContacts() => CurrentViewModel = new ContactListViewModel();

        [RelayCommand]
        private void GoToCreateContact() => CurrentViewModel = new AddContactViewModel();

        [RelayCommand]
        private void GoToEditContact() => CurrentViewModel = new EditContactViewModel();

        [RelayCommand]
        private void CloseApp() { System.Windows.Application.Current.Shutdown(); }

        public MainViewModel()
        {
            CurrentViewModel = new ContactListViewModel();
        }
    }
}
