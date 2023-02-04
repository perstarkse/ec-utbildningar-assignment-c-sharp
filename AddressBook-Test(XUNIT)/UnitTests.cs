using AddressBook_Classes.Models;
using AddressBook_Utilities;
using Adressbok_assignment;
using Adressbok_assignment.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using Spectre.Console;
using System.Collections.ObjectModel;

namespace AddressBook_Test_XUNIT_
{
    public class UnitTests
    {
        private FileService fileService;
        Contact contact = new Contact("firstName", "lastName", "email", "phoneNumber", "address");
        private MainViewModel mainViewModel;

        public UnitTests()
        {
            fileService = new FileService();
            mainViewModel = new MainViewModel();
        }

        [Fact]
        public void AddContact()
        {
            fileService.ContactList.Add(contact);
            Contact lastItemInList = fileService.ContactList.Last();

            Assert.Equal(contact.Email,lastItemInList.Email);
        }
        [Fact]
        public void RemoveContact()
        {
            fileService.ContactList.Add(contact);
            fileService.ContactList.Remove(contact);
            Contact lastItemInList = fileService.ContactList.Last();

            Assert.NotEqual(contact.Email, lastItemInList.Email);
        }
        [Fact]
        public void FindAContact()
        {
            fileService.ContactList.Add(contact);
            //WONT WORK IF LIST CONTAINS TWO OBJECTS WITH IDENTICAL LAST NAMES. 

            var searchResult = ContactSearcher.FindOne("lastName", fileService.ContactList);

            Assert.Equal(contact, searchResult);
        }
        [Fact]
        public void AddSeveralContacts()
        {
            var countBefore = fileService.ContactList.Count;   
            fileService.ContactList.Add(contact);
            fileService.ContactList.Add(contact);   
            var countAfter = fileService.ContactList.Count;

            Assert.True(countBefore < countAfter);
        }

        [Fact]
        public void ShowsAViewmodelOnStart()
        {
            Assert.NotNull(mainViewModel.currentViewModel);
        }
        [Fact]
        public void ChangeViewModel()
        {
            var defaultViewModel = mainViewModel.currentViewModel;
            mainViewModel.GoToCreateContact();
            Assert.NotEqual(defaultViewModel, mainViewModel.currentViewModel);

        }
        [Fact]
        public void NavigateToCreateContactViewModel()
        {
            mainViewModel.GoToCreateContact();
            Assert.IsType<AddContactViewModel>(mainViewModel.currentViewModel);
        }
        [Fact]
        public void DisplaysContactList()
        {
            ContactListViewModel contactListViewModel = new ContactListViewModel();
            mainViewModel.CurrentViewModel = contactListViewModel;
            Assert.NotNull(contactListViewModel.contacts);
        }
    }
}