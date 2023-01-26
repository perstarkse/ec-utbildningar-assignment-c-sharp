using AddressBook_Classes.Models;
using AddressBook_Utilities;
using Adressbok_assignment.Resources.Messenger;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_assignment.ViewModels
{
    public partial class EditContactViewModel : ObservableObject
    {
        private readonly FileService fileService;
        private SimpleMessenger _simpleMessenger;


        public EditContactViewModel()
        {
            fileService = new FileService();
            contacts = fileService.Contacts();
            _simpleMessenger = SimpleMessenger.Instance;
            _simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        private void OnSimpleMessengerValueChanged(object sender, SimpleMessenger.MessageValueChangedEventArgs e)
        {
            firstName = e.selectedContact.FirstName;
            lastName = e.selectedContact.LastName;
            email = e.selectedContact.Email;
            phoneNumber = e.selectedContact.PhoneNumber;
            address = e.selectedContact.Address;
            guid = e.selectedContact.Guid;
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

        [RelayCommand]
        private void SendContact()
        {
            var contactToBeSent = fileService.ContactList.FirstOrDefault(u => u.Guid == Guid);
            _simpleMessenger.RaiseMessageValueChanged(contactToBeSent);
        }
    }
}

