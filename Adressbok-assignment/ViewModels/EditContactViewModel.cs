using AddressBook_Classes.Models;
using AddressBook_Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_assignment.ViewModels
{
    public partial class EditContactViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public EditContactViewModel(Contact _contact)
        {
            fileService = new FileService();
            contacts = fileService.Contacts();
            guid = _contact.Guid;
            firstName = _contact.FirstName;
            lastName = _contact.LastName;
            email = _contact.Email; 
            phoneNumber = _contact.PhoneNumber;
            address = _contact.Address;
        }

        [ObservableProperty]
        private string pageTitle = "Edit a new contact:";
        [ObservableProperty]
        private string firstName;
        [ObservableProperty]
        private string lastName;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string phoneNumber;
        [ObservableProperty]
        private string address;
        [ObservableProperty]
        private Guid guid;


        [ObservableProperty]
        private ObservableCollection<Contact> contacts;

        [RelayCommand]
        private void EditContact()
        {
            var foundUser = fileService.ContactList.FirstOrDefault(u => u.Guid == Guid);
            foundUser.FirstName = firstName;
            foundUser.LastName = lastName;
            foundUser.Email = email;
            foundUser.PhoneNumber = phoneNumber;
            foundUser.Address = address;
            fileService.SaveToFile();
        }
    }
}

