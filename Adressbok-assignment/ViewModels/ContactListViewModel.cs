using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AddressBook_Classes.Models;
using AddressBook_Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adressbok_assignment.ViewModels
{
public partial class ContactListViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public ContactListViewModel(string _index)
        {
            //this.selectedItem = selectedItem;
            fileService = new FileService();
            contacts = fileService.Contacts();
            if (_index != null)
            {
                index = int.Parse(_index);
            }
            else index = 0;
            selectedItem = contacts[index];
        }

        int index;

        [ObservableProperty]
        private ObservableCollection<Contact> contacts;

        [ObservableProperty]
        private Contact selectedItem = null!;

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
