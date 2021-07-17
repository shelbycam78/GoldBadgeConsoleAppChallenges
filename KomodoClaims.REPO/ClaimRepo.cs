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
        private int _Count = 0;
        private Queue<Claim> _claimQueue = new Queue<Claim>();



        //create - adding a claim to the Q
        public bool AddClaimToQueue(Claim claim)
        {
            if (claim ==null)
            {
                return false;
            }
            else
            {
                _Count++;
                claim.ClaimID  = _Count;
                _claimQueue.Enqueue(claim);
                return true;
            }
        }
        public Queue<Claim> GetClaimsQueue()
        {
            return _claimQueue;
        }

        public Claim GetNextClaimReady()
        {
            var claim = _claimQueue.Peek();
            if (claim != null)
            {
                return claim;
            }
            return null;
        }

        public bool ProcessClaim(ClaimType car, Claim newClaim)
        {
            if (_claimQueue.Count  <= 0)
            {
                return false;
            }
            else
            {
                _claimQueue.Dequeue();
                return true;
            }
          
        }
    }
}
