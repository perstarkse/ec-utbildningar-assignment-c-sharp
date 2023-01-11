using AddressBook_Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Utilities
{
    public class UserManagement
    {
        public static Contact Register() {
            Console.WriteLine("Please enter surname:");
            var _firstName = Console.ReadLine();
            Console.WriteLine("Please enter lastname:");
            var _lastName = Console.ReadLine();
            Console.WriteLine("Please enter emailaddress:");
            var _email = Console.ReadLine();
            Console.WriteLine("Please enter phone number:");
            var _phoneNumber = Console.ReadLine();
            Console.WriteLine("Please enter address:");
            var _address = Console.ReadLine();
            var newContact = new Contact(firstName: _firstName, lastName: _lastName, email: _email, phoneNumber: _phoneNumber, address: _address);
            return newContact;
        }
    }
}
