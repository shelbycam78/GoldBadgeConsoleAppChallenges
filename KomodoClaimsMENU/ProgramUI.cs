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
            Console.Clear();
            List<Claim> _listOfClaims = _claimRepo.GetClaimsList();
            foreach (Claim claim in _listOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID}" +
                                  "     " +
                                  $"{ClaimType}" +
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

            Console.ReadKey();
        
        }
        private void GetClaimsQueue()
        {
        }
        private void AddClaimToList()
        {
            Claim newClaim = new Claim();

            Console.WriteLine("Enter the claim ID:");
            newClaim.ClaimID = Console.ReadLine();

            Console.WriteLine("Enter the claim type:");
            newClaim.TypeOfClaim = Console.ReadLine();

            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter amount of damage:");
            newClaim.Amount = Console.ReadLine();

            Console.WriteLine("Enter date of incident:");
            newClaim.DateOfIncident = Console.ReadLine();

            Console.WriteLine("Enter date of claim:");
            newClaim.DateOfClaim = Console.ReadLine();

            Console.WriteLine("Is this claim valid?");
            newClaim.IsValid = Console.ReadLine();


        }

        private void SeedClaims()
        {
            var claimA = new Claim($"{ 1 }", $"{Car}", "Car accident on 465", $"${400.00}", $"{4/25/18}",
                                   $"{4/27/18}", $"{true}");
            Claim claimB = new Claim($"{2}", $"{Home}", "House fire in kitchen", $"${4000.00}", $"{4/11/18}",
                                     $"{4/12/18}", $"{true}");
            Claim claimC = new Claim($"{3}", $"{Theft}", "Stolen pancakes", $"${4.00}", $"{4 / 27 / 18}",
                                     $"{6 / 01 / 18}", $"{false}");
        }
    }
}
