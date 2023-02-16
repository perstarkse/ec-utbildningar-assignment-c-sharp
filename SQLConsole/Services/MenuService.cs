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
        public void CreateNewSite()
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
            database.SaveSiteToDatabase(site);
        }
        public void ListAllAddresses()
        {
            var database = new DBService();
            foreach ( Site site in database.GetSites())
            {
                Console.WriteLine($"Site number: {site.Id}");
                Console.WriteLine($"Site name:  {site.Name}");
                Console.WriteLine($"Site address: {site.Address.AddressField}, {site.Address.ZipCode}, {site.Address.City}\n");
            }
            Console.ReadKey();
        }
        public void ListSpecificContact()
        {
            var database = new DBService();

            Console.Write("Enter site name: ");
            var siteName = Console.ReadLine();
            var site = database.GetSite(siteName);
            if (site != null) { 
            Console.WriteLine($"Site number: {site.Id}");
            Console.WriteLine($"Site name:  {site.Name}");
            Console.WriteLine($"Site address: {site.Address.AddressField}, {site.Address.ZipCode}, {site.Address.City}\n");
            }
            else {
                Console.Clear();
                Console.WriteLine($"No site with the name {siteName} was found");
            }
            Console.ReadKey();
        }
        public void DeleteContact() { }
        public void UpdateContact() { } 
        public void DeleteAll() { }

    }
}
