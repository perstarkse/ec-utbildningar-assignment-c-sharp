using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Classes.Interfaces
{
    public interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }

        abstract void DisplayContact();
    }
}
