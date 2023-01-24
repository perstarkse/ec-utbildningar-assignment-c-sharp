using AddressBook_Classes.Models;
using AddressBook_Utilities;

namespace AddressBook_Test_NUNIT_
{
    public class Tests
    {
        /// <summary>
        /// Tests can be done on a populated or empty json file. 
        /// </summary>
        private FileService fileService;
        Contact contact = new Contact("firstName", "lastName", "email", "phoneNumber", "address");


        [SetUp]
        public void Setup()
        {
            fileService = new FileService();

        }

        [Test]
        public void AddContact()
        {
            fileService.ContactList.Add(contact);
            Contact lastItemInList = fileService.ContactList.Last();

            Assert.That(contact.Email, Is.EqualTo(lastItemInList.Email));
        }
        [Test]
        public void RemoveContact()
        {
            fileService.ContactList.Remove(contact);
            Contact lastItemInList = fileService.ContactList.Last();

            Assert.That(contact.Email, Is.Null.Or.Not.EqualTo(lastItemInList.Email));
        }
        [Test]
        public void FindAContact()
        {
            fileService.ContactList.Add(contact);
            //WONT WORK IF LIST CONTAINS TWO OBJECTS WITH IDENTICAL LAST NAMES. 

            var searchResult = ContactSearcher.FindOne("lastName", fileService.ContactList);

            Assert.That(contact, Is.EqualTo(searchResult));
        }
    }
}