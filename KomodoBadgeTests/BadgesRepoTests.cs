using KomodoBadges.POCO;
using KomodoBadges.REPO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoBadges.Tests
{
    [TestClass]
    public class BadgesRepoTests
    {
        private BadgeRepo _repo;
        private Badge _badge;


        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _badge = new Badge();

            _repo.AddBadgeToDictionary(new Badge());

        }

        [TestMethod]
        public void AddBadgeTest()
        {
            Badge badge = new Badge();
            badge.BadgeID = 1;

            int expected = 1;
            int actual = badge.BadgeID;

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