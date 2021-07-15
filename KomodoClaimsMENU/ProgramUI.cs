using KomodoClaims.POCO;
using KomodoClaims.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsMENU
{
    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            SeedClaims();
            Menu();
        }
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Please choose a menu item: \n" +
                                  "1.  See all claims \n" +
                                  "2.  Take care of next claim \n" +
                                  "3.  Enter a new claim \n");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GetClaimsList();
                        break;
                    case "2":
                        GetClaimsQueue();
                        break;
                    case "3":
                        AddClaimToList();
                        break;
                }

                Console.ReadKey();
            }
        }
        private void GetClaimsList()
        {
            
            Queue<Claim> _listOfClaims = _claimRepo.GetClaimsQueue();
            foreach (Claim claim in _listOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID}" +
                                  "     " +
                                  $"{claim.TypeOfClaim}" +
                                  "     " +
                                  $"{claim.Description}" +
                                  "     " +
                                  $"{claim.Amount}" +
                                  "     " +
                                  $"{claim.DateOfIncident}" +
                                  "     " +
                                  $"{claim.DateOfClaim}" +
                                  "     " +
                                  $"{claim.IsValid}");
            }
            Console.WriteLine("Press any key to return to continue.");    
        }
        private void GetClaimsQueue()
        {
            Console.Clear();
            Claim claim = _claimRepo.GetNextClaimReady();
            Console.WriteLine($"{claim.ClaimID}" +
                                  "     " +
                                  $"{claim.TypeOfClaim}" +
                                  "     " +
                                  $"{claim.Description}" +
                                  "     " +
                                  $"{claim.Amount}" +
                                  "     " +
                                  $"{claim.DateOfIncident}" +
                                  "     " +
                                  $"{claim.DateOfClaim}" +
                                  "     " +
                                  $"{claim.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now? y/n");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                var success = _claimRepo.ProcessClaim();
                if (success)
                {
                    Console.WriteLine("The claim has been processed.");
                }
                else
                {
                    Console.WriteLine("The claim failed to be processed.");
                }
            }
            else Run();

            Console.ReadKey();
        }
        private void AddClaimToList()
        {
            
            Console.WriteLine("Enter the claim type - 1 = Car, 2 = Home, 3 = Theft");
            int claimTypeNumber = int.Parse(Console.ReadLine());
            var claimType = (ClaimType)claimTypeNumber;

            Console.WriteLine("Enter a claim description:");
            var claimDescription = Console.ReadLine();

            Console.WriteLine("Enter amount of damage:");
            var claimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of incident - m/d/yy:");
            var claimDateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of claim - m/d/yy:");
            var claimDateOfClaim = DateTime.Parse(Console.ReadLine());

            Claim claim = new Claim(claimType, claimDescription, claimAmount, claimDateOfIncident, claimDateOfClaim);

            var success = _claimRepo.AddClaimToQueue(claim);
            if (success)
            {
                Console.WriteLine("The claim is valid and has been successfully added.");
            }
            else
            {
                Console.WriteLine("This claim is not valid.");
            }
        }

        private void SeedClaims()
        {
            var claimA = new Claim(ClaimType.Car, "Car accident of 465", decimal.Parse("400.00"),
                                   DateTime.Parse("4/25/18"), DateTime.Parse("4/27/18"));

            Claim claimB = new Claim(ClaimType.Home, "House fire in Kitchen", decimal.Parse("4000.00"),
                                     DateTime.Parse("4/11/18"), DateTime.Parse("4/12/18"));

            Claim claimC = new Claim(ClaimType.Theft, "Stolen pancakes.", decimal.Parse("4.00"),
                                     DateTime.Parse("4/27/18"), DateTime.Parse("6/01/18"));

            _claimRepo.AddClaimToQueue(claimA);
            _claimRepo.AddClaimToQueue(claimB);
            _claimRepo.AddClaimToQueue(claimC);

        }
    }
}
