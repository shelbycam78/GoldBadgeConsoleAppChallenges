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
        public void GetBadgeByBadgeIDTest()
        {
            Badge badgeID = new Badge();
            badgeID.BadgeID = 1;

            int expected = 1;
            int actual = badgeID.BadgeID;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EditBadgeTest()
        {
            Badge newBadge = new Badge(22345, new Badge);

            bool updateResult =

            Assert.IsTrue(updateResult);
        }

    }
}