using SQLConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsole.Services
{
    internal class MenuService
    {
        public void CreateSite()
        {
            var site = new Site();
            Console.Write("Name: ");
            site.Name = Console.ReadLine() ?? "";
            Console.Write("Address: ");
            site.Address.AddressField = Console.ReadLine() ?? "";
            Console.Write("City: ");
            site.Address.City = Console.ReadLine() ?? "";
            Console.Write("ZipCode: ");
            site.Address.ZipCode = Console.ReadLine() ?? "";

            var database = new DBService();
            database.SaveToDatabase(site);
        }
        public void ListAllAddresses()
        {

        }
        public void ListSpecificContact()
        {

        }
        public void DeleteContact() { }
        public void UpdateContact() { } 
        public void DeleteAll() { }

    }
}
