using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adressbok_assignment.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        [RelayCommand]
        private void GoToContacts() => CurrentViewModel = new ContactListViewModel();

        [RelayCommand]
        private void GoToCreateContact() => CurrentViewModel = new AddContactViewModel();

        public MainViewModel()
        {
            CurrentViewModel = new ContactListViewModel();
        }
    }
}
