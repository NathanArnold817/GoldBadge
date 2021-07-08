using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
   public class Badges
    {
        public int BadgeNumber { get; set; }
        public List<string> DoorAccess { get; set; }

        public Badges() { }
        public Badges(int badgeNumber, List<string> doorAccess)
        {
            BadgeNumber = badgeNumber;
            DoorAccess = doorAccess;
        }
    }
}
