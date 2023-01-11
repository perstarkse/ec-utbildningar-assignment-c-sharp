using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AddressBook_Classes.Models;

namespace AddressBook_Utilities
{
    public class ContactSearcher
    {
        public static Contact FindOne(string _lastName, List<Contact> ContactList)
        {
            if (_lastName is null)
            {
                throw new ArgumentNullException(nameof(_lastName));
            }

            List<Contact> SearchResult = new List<Contact>();
            foreach (Contact contact in ContactList)
            {
                if (contact.LastName.ToUpper() == _lastName.ToUpper())
                {
                    SearchResult.Add(contact);
                }
            }
            if (SearchResult.Count > 1)
            {
                Console.WriteLine("Found these searchresults: ");
                for (int i = 0; i < SearchResult.Count; i++)
                {
                    Console.WriteLine($" {i}: {SearchResult[i].Guid} - {SearchResult[i].FirstName} {SearchResult[i].LastName}");
                }
                Console.WriteLine("Please select your contact: ");
                int.TryParse(Console.ReadLine(), out int _selection);
                var _result = SearchResult[_selection];
                return _result;
            }
            if (SearchResult.Count == 0)
            {
                return new Contact(firstName: "No contact with this name found", lastName: "", email: "", phoneNumber: "", address: "");
            }
            else
            {
                return SearchResult[0];
            }
        }
    }
}
