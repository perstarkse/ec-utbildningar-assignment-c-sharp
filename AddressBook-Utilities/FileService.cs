using AddressBook_Classes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Utilities
{
    public class FileService
    {
        string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
        public List<Contact> ContactList; 

        public FileService()
        {
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                ContactList = JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd())!;
            }
            catch { ContactList = new List<Contact>();}
        }
        public void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(ContactList));
        }

        public ObservableCollection<Contact> Contacts()
        {
            var items = new ObservableCollection<Contact>();
            foreach (var contact in ContactList)
            {
                items.Add(contact);
            }
            return items;
        }
    }
}
