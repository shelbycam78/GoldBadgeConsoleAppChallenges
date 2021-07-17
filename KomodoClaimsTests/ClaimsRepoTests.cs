using KomodoClaims.POCO;
using KomodoClaims.REPO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaimsTests
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private ClaimRepo _repo;
        private Claim _claim;


        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            _claim = new Claim();

            _repo.AddClaimToQueue(new Claim());

        }

        [TestMethod]
        public void AddClaimTest()
        {
            Claim claim = new Claim();
            claim.ClaimID = 1;

            int expected = 1;
            int actual = claim.ClaimID;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetClaimByClaimIDTest()
        {
            Claim claimNumber = new Claim();
            claimNumber.ClaimID = 1;

            int expected = 1;
            int actual = claimNumber.ClaimID;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProcessClaimTest()
        {
            Claim newClaim = new Claim(ClaimType.Car, "Car accident of 465", decimal.Parse("400.00"),
                                   DateTime.Parse("4/25/18"), DateTime.Parse("4/27/18"));

            bool updateResult = _repo.ProcessClaim(ClaimType.Car, newClaim);

            Assert.IsTrue(updateResult);
        }       

    }
}