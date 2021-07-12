using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.POCO
{
    public enum ClaimType { Car, Home, Theft }
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
        public Claim(int claimID, ClaimType claimType, string description,
                      decimal amount, DateTime dateOfIncident, 
                      DateTime dateOfClaim, bool isValid)
            {
                ClaimID = claimID;
                TypeOfClaim = claimType;
                Description = description;
                Amount = amount;
                DateOfIncident = dateOfIncident;
                DateOfClaim = dateOfClaim;
            }
    }
}
