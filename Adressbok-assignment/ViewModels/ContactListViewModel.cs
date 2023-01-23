using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook_Classes.Models;
using AddressBook_Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adressbok_assignment.ViewModels
{
public partial class ContactListViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public ContactListViewModel()
        {
            fileService = new FileService();
            contacts = fileService.Contacts();
        }
        [ObservableProperty]
        private ObservableCollection<Contact> contacts;

        [RelayCommand]
        private void RemoveContact(Contact selectedItem)
        {
            contacts.Remove(selectedItem);
            fileService.ContactList.Remove(selectedItem);
            fileService.SaveToFile();
        }
    }
}
