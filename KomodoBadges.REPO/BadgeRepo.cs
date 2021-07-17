using KomodoBadges.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges.REPO
{
    public class BadgeRepo
    {
        private int _Count = 0;
        Dictionary<int, List<string>> _myDictionary = new Dictionary<int, List<string>>();
        public bool AddBadgeToDictionary(Badge badge)
        {
            if (badge == null)
            {
                return false;
            }
            else
            {
               
                _myDictionary.Add(badge.BadgeID, badge.DoorNames);
                return true;
            }
        }

        //show queue
        public Dictionary<int, List<string>> ListDictionary()
        {
            return _myDictionary;       
        }


        //update badges - add door, remove door, remove all doors, return to menu
        public void EditBadge(Badge badge)
        {
            
                if (_myDictionary.ContainsKey(badge.BadgeID))
                {
                    _myDictionary[badge.BadgeID] = badge.DoorNames;
                }
                else
                {
                    _myDictionary.Add(badge.BadgeID, badge.DoorNames);
                }
                


            //similar forach as badge by id
        }
        //delete all rooms from badge
        public void DeleteDoors()
        {
        
        }

        //helper method - grabs badge by id
        public Badge GetBadgeByID(int badgeID)
        {
            foreach (KeyValuePair<int,List<string>> keyValuePair in _myDictionary)
            {
                if (keyValuePair.Key == badgeID)
                {
                    return new Badge(keyValuePair.Key, keyValuePair.Value);
                    
                }
            }
            return null;
        }
    }
}
