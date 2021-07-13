using KomodoClaims.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.REPO
{
    public class ClaimRepo
    {
        private List<Claim> _listOfClaims = new List<Claim>();
        private int _Count = 0;
        private Queue<Claim> _claimQueue = new Queue<Claim>();



        //create - adding a claim to the Q
        public bool AddClaimToList(Claim claim)
        {
            if (claim ==null)
            {
                return false;
            }
            else
            {
                _Count++;
                claim.ClaimID  = _Count;
                _listOfClaims.Add(claim);
                return true;
            }
        }

        public bool AddClaimToQueue(Claim claim)
        {
            if (claim == null)
            {
                return false;
            }
            else
            {
                _claimQueue.Enqueue(claim);
                return true;
            }
        }

        //read - show all claims
        public List<Claim> GetClaimsList() 
        {
            return _listOfClaims;
        }
        public Queue<Claim> GetClaimsQueue()
        {
            return _claimQueue;
        }

        public void GetNextClaimReady()
        {
            _claimQueue.Peek();
        }
    }
}
