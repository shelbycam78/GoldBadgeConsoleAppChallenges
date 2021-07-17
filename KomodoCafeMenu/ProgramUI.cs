using KomodoCafe.POCO;
using KomodoCafe.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenu
{
    class ProgramUI
    {
        private CafeItemRepo _cafeItemREPO = new CafeItemRepo();
        public void Run()
        {
            //SeedCafeItems();
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
                                  "************************\n" +
                                  "1.  Add a dish to the Menu\n" +
                                  "2.  Remove a dish from the Menu\n" +
                                  "3.  Display the Menu\n" +
                                  "4.  Exit");

                //take in input from user
                var selection = Console.ReadLine();

                //evaluate user input and act accordingly
                switch (selection)
                {
                    case "1":
                        AddDishToMenu();
                        break;
                    case "2":
                        RemoveDishFromMenu();
                        break;
                    case "3":
                        DisplayDishList();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        break;

                    default:
                        System.Console.WriteLine("Please enter a valid number.");
                        isRunning = false;
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddDishToMenu()
        {
            CafeItemPoco newCafeItem = new CafeItemPoco();         

            //number, name, info(description), ingredients, cost
            Console.WriteLine("Please enter a Name for the dish:");
            newCafeItem.Name = Console.ReadLine();

            Console.WriteLine("Please enter a description of the dish:");
            newCafeItem.Info = Console.ReadLine();

            Console.WriteLine("Please list the ingredients of the dish:");
            string ingredient1 = Console.ReadLine();
            newCafeItem.Ingredients.Add(ingredient1);

            bool whileRunning = true;
            while (whileRunning)
            {
                Console.WriteLine("Do you have more ingredients to add? (y/n)");
                var input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    Console.WriteLine("Enter the next ingredient:");
                    var ingredient2 = Console.ReadLine();
                    newCafeItem.Ingredients.Add(ingredient2);
                }
                else if (input == "n")
                {
                    whileRunning = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection:");
                }
            }
            Console.WriteLine("Please enter the price of the dish (4.99, 1.00, .50, etc.):");
            string itemCost = Console.ReadLine();
            newCafeItem.Cost = decimal.Parse(itemCost);

            //repo, call method - pass in input, 
            _cafeItemREPO.AddItemsToMenu(newCafeItem);

            Console.ReadKey();
        }
        private void RemoveDishFromMenu()
        {

            DisplayDishList();

            //get item to delete from user
            Console.WriteLine("Enter dish # to remove from the Menu:");
            int id = int.Parse(Console.ReadLine());

            //call delete method
            _cafeItemREPO.DeleteItemsFromMenu(id);

            Console.ReadKey();
        }
        private void DisplayDishList()
        {
            Console.Clear();
            List<CafeItemPoco> _listOfDishes = _cafeItemREPO.GetDishList();
            foreach (CafeItemPoco dish in _listOfDishes)
            {
                Console.WriteLine($"#{dish.Number}\n" +
                                  $"{dish.Name} ------- {dish.Cost}\n" +
                                  $"{dish.Info}\n");
                foreach (var item in dish.Ingredients)
                {
                    Console.WriteLine($"{item}");
                }
                                
            }
        }

        //private void SeedCafeItems()
        //{
        //    var dishA = new CafeItemPoco("Grilled Cheese", $"{ dishA.Cost}", , "Childhood ain't cheap but it sure tastes good.", "2 slices of bread without crust, 2 kraft cheese slices");
        //    CafeItemPoco dishB = new CafeItemPoco("Apple Slices", "$3.99/lb", "Your choice of apple -- Pink Delicious, Granny Smith, HoneyCrisp.", "apple");
        //    CafeItemPoco dishC = new CafeItemPoco("Ceasar Salad", "12.99", "No going halvsies.  You get the big salad.", $"{dishC.Ingredients}");
        //    CafeItemPoco dishD = new CafeItemPoco();

        //    _cafeItemREPO.AddItemsToMenu(dishA);
        //    _cafeItemREPO.AddItemsToMenu(dishB);
        //    _cafeItemREPO.AddItemsToMenu(dishC);
        //    _cafeItemREPO.AddItemsToMenu(dishD);
        //}*/
    }
}
