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
        public ObservableObject currentViewModel;

        [RelayCommand]
        public void GoToContacts() => CurrentViewModel = new ContactListViewModel();

        [RelayCommand]
        public void GoToCreateContact() => CurrentViewModel = new AddContactViewModel();

        [RelayCommand]
        public void GoToEditContact() => CurrentViewModel = new EditContactViewModel();

        [RelayCommand]
        public void CloseApp() { System.Windows.Application.Current.Shutdown(); }

        public MainViewModel()
        {
            CurrentViewModel = new ContactListViewModel();
        }
    }
}
