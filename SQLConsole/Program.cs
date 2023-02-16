using SQLConsole.Services;
using System.ComponentModel.DataAnnotations.Schema;

bool isRunning = true;
do
{
    DBService database = new DBService();
    MenuService menu = new MenuService();
    Console.Clear();
    Console.WriteLine("WELCOME TO THE GRAND MENU\n");
    Console.WriteLine("1. Create new site");
    Console.WriteLine("2. Show all sites");
    Console.WriteLine("3. Show a specific site");
    Console.WriteLine("4. Select to exit");
    Console.WriteLine("Select one of the above");


    int.TryParse(Console.ReadLine(), out int selection);
    switch (selection)
    {
        case 1:
            menu.CreateNewSite();
            break;
        case 2:
            menu.ListAllAddresses();
            break;
        case 3:
            menu.ListSpecificContact();
            break;
        case 4:
            Console.WriteLine("exitted");
            isRunning = false;
            break;
        default:
            Console.WriteLine("press the right buttons yo");
            break;
    }
} while (isRunning);