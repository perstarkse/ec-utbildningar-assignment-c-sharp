using AddressBook_Classes.Models;
using AddressBook_Utilities;

namespace Addressbook_Tests_MSTest_
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
            Contact lastItemInList = fileservice.ContactList.Last();

            Assert.AreEqual(2000, fileService.ContactList.Count);

        }
    }
}