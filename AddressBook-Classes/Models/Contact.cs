using AddressBook_Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Classes.Models
{
    public class Contact : IContact
    {
        public Contact(string firstName, string lastName, string email, string phoneNumber, string address)
        {
            Guid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public Guid Guid { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public void DisplayContact()
        {
           Console.WriteLine($"\nFirst name: {FirstName}\nLast name: {LastName}\nEmail: {Email}\nPhone number: {PhoneNumber}\nAddress: {Address}");
        }
    }
}
