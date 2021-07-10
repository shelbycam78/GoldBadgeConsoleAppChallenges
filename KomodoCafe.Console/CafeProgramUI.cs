using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe.Console
{
    class CafeProgramUI
    {
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                //display to user
                Console.WriteLine("Please Make a Selection:\n" +
                                  "*************************************\n" +
                                  "1.  Add a dish to the Menu\n" +
                                  "2.  Remove a dish from the Menu\n" +
                                  "3.  Display the Menu\n" +
                                  "4.  Exit");

                //take in input from user
                var selection = Console.Readline();

                //evaluate user input and act accordingly
                switch (selection)
                {
                    case "1":
                        AddItemToMenu();
                        break;
                    case "2":
                        RemoveItemFromMenu();
                        break;
                    case "3":
                        DisplayMenu();
                        break;
                    case "4":
                        System.Console.WriteLine("Goodbye");
                        break;


                    default:
                        System.Console.WriteLine("Please enter a valid number.");
                        isRunning = false;
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.Readkey();
                Console.Clear();
            }
        }
        
        private void AddItemToMenu() 
        {
        
        
        }
        private void RemoveItemFromMenu() { }
        private void DisplayMenu() { }






    }
}
