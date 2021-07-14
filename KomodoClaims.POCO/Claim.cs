using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.POCO
{
    public enum ClaimType {Car = 1, Home , Theft }
    
    public class Claim
    {        
        public int ClaimID { get; set; }

        public ClaimType TypeOfClaim { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid { get; set; }


        public Claim() { }
        public Claim(ClaimType claimType, string description,
                      decimal amount, DateTime dateOfIncident, 
                      DateTime dateOfClaim)
            {
                TypeOfClaim = claimType;
                Description = description;
                Amount = amount;
                DateOfIncident = dateOfIncident;
                DateOfClaim = dateOfClaim;
                IsValid = isClaimValid(DateOfIncident,DateOfClaim);
            }
        private bool isClaimValid(DateTime dateOfIncident, DateTime dateOfClaim)
        {
            var span = dateOfClaim - dateOfIncident;
            Console.WriteLine($"Total Days: {span.TotalDays}");
            if (span.TotalDays >30)
            {
                return IsValid = false;
            }
            else
            {
                return IsValid = true;
            }
        
        }
    }
}
