using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AddressBook_Classes.Models;
using AddressBook_Utilities;
using Adressbok_assignment.Resources.Messenger;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adressbok_assignment.ViewModels
{
public partial class ContactListViewModel : ObservableObject
    {
        private readonly FileService fileService;
        private SimpleMessenger _simpleMessenger;


        public ContactListViewModel()
        {
            fileService = new FileService();
            contacts = fileService.Contacts();
            _simpleMessenger = SimpleMessenger.Instance;
            _simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        private void OnSimpleMessengerValueChanged(object sender, SimpleMessenger.MessageValueChangedEventArgs e)
        {
            int itemIndex = contacts.IndexOf(contacts.Where(x => x.Guid == e.selectedContact.Guid).FirstOrDefault());
            if (itemIndex < 0)
            {

            }
            else
            {
                selectedItem = contacts[itemIndex];
            }
        }

        [ObservableProperty]
        private ObservableCollection<Contact> contacts;

        [ObservableProperty]
        private Contact selectedItem = null!;

        [RelayCommand]
        private void SendContact(Contact selectedItem)
        {
            _simpleMessenger.RaiseMessageValueChanged(selectedItem);
        }

        [RelayCommand]
        private void RemoveContact(Contact selectedItem)
        {
            MessageBoxResult confirmation = MessageBox.Show("Do you really want to delete this contact?","yes", MessageBoxButton.OKCancel);
            if (confirmation == MessageBoxResult.OK) {
                contacts.Remove(selectedItem);
                fileService.ContactList.Remove(selectedItem);
                fileService.SaveToFile();
            }
            else { }
        }
    }
}
