using AddressBook_Classes.Models;
using AddressBook_Utilities;

namespace AddressBook_Test_XUNIT_
{
    public class UnitTests
    {
        private FileService fileService;
        Contact contact = new Contact("firstName", "lastName", "email", "phoneNumber", "address");


        public UnitTests()
        {
            fileService = new FileService();
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
    }
}