using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges.POCO
{
    public class Badge
    {
        public int BadgeID { get; set; }        

        public List<string> DoorNames = new List<string>();        

        
        public Badge() { }
        public Badge(int badgeID, List<string> doorNames)
        { 
                BadgeID = badgeID;
                DoorNames = doorNames;
        }

        
    }
}
