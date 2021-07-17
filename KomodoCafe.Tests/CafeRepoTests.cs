using KomodoCafe.POCO;
using KomodoCafe.REPO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafe.Tests
{
    [TestClass]
    public class CafeRepoTests
    {
        private CafeItemRepo _repo;
        private CafeItemPoco _dish;
        
        
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeItemRepo();
            _dish = new CafeItemPoco();

            _repo.AddItemsToMenu(new CafeItemPoco());
                
        }

        [TestMethod]
        public void AddDishTest()
        {
            CafeItemPoco cafeItem = new CafeItemPoco();
            cafeItem.Number = 1;

            int expected = 1 ;
            int actual = cafeItem.Number;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetItemByNumberTest()
        {
            CafeItemPoco dishNumber = new CafeItemPoco();
            dishNumber.Number = 1 ;

            int expected = 1;
            int actual = dishNumber.Number;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteDishTest()
        {

            bool deleteResult = _repo.DeleteItemsFromMenu(_dish.Number);

            Assert.IsTrue(deleteResult);
        }
        
    }
}
