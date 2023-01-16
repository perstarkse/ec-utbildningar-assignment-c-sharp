using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook_Classes.Models;
using AddressBook_Utilities;
using CommunityToolkit.Mvvm.ComponentModel;


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
        private string pageTitle = "Contacts:";
        [ObservableProperty]
        private ObservableCollection<Contact> contacts;
    }
}
