using AddressBook_Classes.Models;
using AddressBook_Utilities;
using Adressbok_assignment.Controls;
using Adressbok_assignment.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Adressbok_assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
        private ObservableCollection<Contact> ContactList = new();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                ContactList = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(FileService.Read(filePath));
            }
            catch (Exception ex) { }

            lv_ContactList.ItemsSource = ContactList;
            frame_PageFrame.Navigate(new Uri("/Pages/Contacts.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var newContact = new Contact(firstName: tb_FirstName.Text, lastName: tb_LastName.Text, email: tb_Email.Text, phoneNumber: tb_PhoneNumber.Text, address: tb_Address.Text);
            ContactList.Add(newContact);
            FileService.Save(filePath, JsonConvert.SerializeObject(ContactList));
            ClearForm();
        }

        private void ClearForm()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_PhoneNumber.Text = "";
            tb_Address.Text = "";
        }

        private void Lbox_NavMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = Lbox_NavMenu.SelectedItem as NavButton;
            frame_PageFrame.Navigate(selected?.NavLink);
        }
    }
}
