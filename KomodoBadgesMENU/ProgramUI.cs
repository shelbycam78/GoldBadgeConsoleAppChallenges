using KomodoBadges.POCO;
using KomodoBadges.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgesMENU
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();        

        public void Run()
        {
            SeedBadges();
            Menu();
        }

        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Please select an option from the \n" +
                                  "*********************************\n" +
                                  "1.  Add a badge\n" +
                                  "2.  Edit a badge\n" +
                                  "3.  List all badges");
            
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                }
                Console.ReadKey();
            }
        }
        private void AddBadge()
        {
            Badge newBadge = new Badge();

            //1.  Add number to Badge
            Console.WriteLine("Enter the number on the badge:\n");
            newBadge.BadgeID = int.Parse(Console.ReadLine());

            //2.  List a door to add access
            Console.WriteLine("List a door it needs access to:\n");
            string door = Console.ReadLine().ToUpper();
            newBadge.DoorNames.Add(door);            

            //4.  yes thru list, no back to main menu
            
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Any other doors? (y/n)\n");
                var result = Console.ReadLine().ToLower();

                if (result == "y")
                {
                    Console.WriteLine("List a door it needs access to:\n");
                    string door2 = Console.ReadLine().ToUpper();
                    newBadge.DoorNames.Add(door2);
                }
                else if (result == "n")
                {
                    _badgeRepo.AddBadgeToDictionary(newBadge);
                    isRunning = false;
                    Console.Clear();
                }
            }
        }

        private void EditBadge()
        {
            //1.  Enter Badge number to update
            Console.WriteLine("What is the badge number to update?");
            var badgeNumber = Console.ReadLine();
            
            var badge = _badgeRepo.GetBadgeByID(int.Parse(badgeNumber));
            Console.WriteLine($"{badgeNumber} has access to {String.Join(", ", badge.DoorNames)}");

            //2.  What would you like to do?
            bool whileRunning = true;
            while (whileRunning)
            {
                Console.WriteLine("What would you like to do:\n" +
                                 "1.  Add a door\n" +
                                 "2.  Remove a door\n" +
                                 "3.  Remove all doors\n" +
                                 "4.  Return to the Main Menu");
                int selection = int.Parse(Console.ReadLine());
                if (selection == 1)
                {
                    Console.WriteLine("Which door would you like to add?");
                    string input = Console.ReadLine().ToUpper();
                    badge.DoorNames.Add(input);

                    Console.WriteLine($"Door Access Added to {badgeNumber}");
                }
                else if (selection == 2)
                {
                    Console.WriteLine("Which door would you like to remove?");
                    string input = Console.ReadLine().ToUpper();
                    badge.DoorNames.Remove(input);
                    Console.WriteLine("Door Removed");
                }
                else if (selection == 3)
                {
                    Console.WriteLine("All doors have been removed");
                    badge.DoorNames.Clear();
                    _badgeRepo.EditBadge(badge);
                }
                else if (selection == 4)
                {
                    whileRunning = false;
                    _badgeRepo.EditBadge(badge);
                    Console.Clear();                    
                }
            }
        }
        private void ListBadges()
        {
            //left column BadgeID
            //right column Door Access
            Console.Clear();
            Dictionary<int, List<string>> _listDictionary = _badgeRepo.ListDictionary();
            Console.WriteLine("Badge#       Door");
         
            foreach (KeyValuePair<int, List<string>> keyValuePair in _listDictionary)
            {
                Console.WriteLine($"{keyValuePair.Key}      {string.Join(", ",keyValuePair.Value)}");
            }            
        }

        private void SeedBadges()
        {

            var badgeA = new Badge(12345, new List<string>()
            {"A7"});
            
            Badge badgeB = new Badge(22345, new List<string>()
            {"A1","A4", "B1", "B2"});

            Badge badgeC = new Badge(32345, new List<string>()
            {"A4","A5"});

            _badgeRepo.AddBadgeToDictionary(badgeA);
            _badgeRepo.AddBadgeToDictionary(badgeB);
            _badgeRepo.AddBadgeToDictionary(badgeC);
       }
    }
}
