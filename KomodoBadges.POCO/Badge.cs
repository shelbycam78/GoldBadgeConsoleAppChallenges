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
        public string BadgeName { get; set; }

        public List<string> DoorNames = new List<string>();
        


        public Badge() { }
        public Badge(int badgeID, string badgeName, List<string> doorNames)
        { {
                BadgeID = badgeID;
                BadgeName = badgeName;
                DoorNames = doorNames;
          }


    }
}
