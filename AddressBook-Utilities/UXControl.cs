using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Utilities
{
    public class UXControl
    {
        public static bool YesOrNo(string _action)
        {
            Console.WriteLine($"\nDo you really want to {_action}? \nPress y to do so, and n to abort: \n");
            bool correctInput = false;
            while (!correctInput)
            {
                switch (Console.ReadLine())
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("\nPlease press y or no! \n");
                        break;
                }
            }
            return false;
        }
        public static void ClearConsole()
        {
            Console.WriteLine("\nPress any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
