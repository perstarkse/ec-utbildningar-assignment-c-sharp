using AddressBook_Classes.Models;
using AddressBook_Utilities;

namespace Addressbook_Tests_MSTest_
{
    [TestClass]
    public class UnitTests
    {
        private List<Contact> contacts;

        [TestMethod]
        public void AddAContact()
        {
            FileService fileservice = new FileService();
            contacts = fileservice.ContactList;
            Contact mockContact = new Contact("firstName", "lastName", "email", "phoneNumber", "address");
            contacts.Add(mockContact);
            Contact lastItemInList = contacts.Last();
            Assert.That.Equals(lastItemInList.FirstName == "firstName");
        }
    }
}