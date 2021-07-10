using KomodoCafe.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe.REPO
{
    public class CafeItemRepo
    {
        private List<CafeItemPoco> _listOfItems = new List<CafeItemPoco>();
        private int _Count = 0;

        //create -add items to list
        public bool AddItemsToMenu(CafeItemPoco item)
        {
            if (item == null)
            {
                return false;
            }
            else
            {
                _Count++;
                item.Number = _Count;
                _listOfItems.Add(item);
                return true;
            }      
        }

        //read the list
        public List<CafeItemPoco> GetDishList()
        {
            return _listOfItems;
        }
        //upate not needed
        //delete items from list
        public bool DeleteItemsFromMenu(int id)
        {
            foreach (var item in _listOfItems)
            {
                if (item.Number == id)
                {
                    _listOfItems.Remove(item);
                    return true;
                }
            }
            return false;
        }
        //helper method
        private CafeItemPoco GetItemByNumber(int id)
        {
            foreach (CafeItemPoco item in _listOfItems)
            {
                if (item.Number == id)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
