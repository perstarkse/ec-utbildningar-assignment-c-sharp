using AddressBook_Classes.Models;
using AddressBook_Utilities;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.CompilerServices;

FileService fileService = new();
bool isRunning = true;
do
{
    Console.Clear();
    Console.WriteLine("\nWelcome to the addressbook \n\n1.Create a contact \n2.Show all contacts \n3.Show a Specific contact \n4.Remove a specific contact \n5.Exit the application \n\nChoose one of the options above: \n");
    int.TryParse(Console.ReadLine(), out int selection);

    switch (selection)
    {
        case 1:
            Console.Clear();
            var newContact = UserManagement.Register();
            fileService.ContactList.Add(newContact);
            fileService.SaveToFile();
            Console.Clear();
            Console.WriteLine("Successfully added a new contact: "); 
            newContact.DisplayContact();
            UXControl.ClearConsole();
            break;
        case 2:
            Console.Clear();
            foreach (Contact contact in fileService.ContactList)
            {
                Console.WriteLine($"------------------------------------------------------\nContact: {contact.FirstName} {contact.LastName} with emailaddress: {contact.Email}\n------------------------------------------------------");
            }
            UXControl.ClearConsole();
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("\nPlease enter the lastname of the contact you wish to search for: \n");
            var _search = Console.ReadLine();
            var result = ContactSearcher.FindOne(_search, fileService.ContactList);
            Console.Clear();
            result.DisplayContact();
            UXControl.ClearConsole();
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("\nPlease enter the lastname of the contact you wish to delete (you must enter their full lastname): \n");
            var _delSearch = Console.ReadLine();
            var delResult = ContactSearcher.FindOne(_delSearch, fileService.ContactList);
            Console.Clear();
            delResult.DisplayContact();
            bool answer = UXControl.YesOrNo("delete this contact");
            if (answer) {
                fileService.ContactList.Remove(delResult); Console.WriteLine("\nRemoved the contact...");
                fileService.SaveToFile();
            }
            else { Console.WriteLine("\nDid nothing..."); }
            UXControl.ClearConsole();
            break;
        case 5: 
            Console.Clear();
            Console.WriteLine("Closing down shop....");
            isRunning= false;
            break;
        default:
            Console.WriteLine("Choose one of the correct alternatives\n");
            break;
    }
} while (isRunning);