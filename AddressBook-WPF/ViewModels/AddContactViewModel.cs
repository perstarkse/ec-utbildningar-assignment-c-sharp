using AddressBook_Classes.Models;
using AddressBook_Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_assignment.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public AddContactViewModel()
        {
            fileService = new FileService();
        }

        [ObservableProperty]
        private string pageTitle = "Create a new contact:";
        [ObservableProperty]
        private string firstName = string.Empty;
        [ObservableProperty]
        private string lastName = string.Empty;
        [ObservableProperty]
        private string email = string.Empty;
        [ObservableProperty]
        private string phoneNumber = string.Empty;
        [ObservableProperty]
        private string address = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;
        [RelayCommand]
        private void AddContact()
        {
            fileService.ContactList.Add(new Contact(FirstName, LastName, Email, PhoneNumber, Address));
            fileService.SaveToFile();
            ClearForm();
        }

        private void ClearForm()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            PhoneNumber = "";
            Address = "";
        }
    }
}
