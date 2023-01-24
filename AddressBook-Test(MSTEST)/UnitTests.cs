using AddressBook_Classes.Models;
using AddressBook_Utilities;

namespace AddressBook_Test_MSTEST_
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void AddAContact()
        {
            FileService fileService = new FileService();
            Contact contact = new Contact("firstName", "lastName", "email", "phoneNumber", "address");

            fileService.ContactList.Add(contact);
            Contact lastItemInList = fileService.ContactList.Last();

            Assert.AreEqual(contact.Email, lastItemInList.Email);
        }
        [TestMethod]
        public void RemoveAContact()
        {
            FileService fileService = new FileService();
            Contact contact = new Contact("firstName", "lastName", "email", "phoneNumber", "address");
            fileService.ContactList.Add(contact);
            var count = fileService.ContactList.Count();   

            fileService.ContactList.Remove(contact);

            Assert.AreNotEqual(count, fileService.ContactList.Count);
        }
        [TestMethod]
        public void FindAContact()
        {
            FileService fileService = new FileService();
            Contact contact = new Contact("firstName", "lastName", "email", "phoneNumber", "address");
            fileService.ContactList.Add(contact);
            //WONT WORK IF LIST CONTAINS TWO OBJECTS WITH IDENTICAL LAST NAMES. 

            var searchResult = ContactSearcher.FindOne("lastName", fileService.ContactList);

            Assert.AreEqual(contact.FirstName, searchResult.FirstName);
        }
    }
}