using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
   public class BadgesRepository
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();
        protected readonly List<Badges> _contentDirectory = new List<Badges>();

        public bool AddBadge(Badges newContent)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(newContent);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Badges> View()
        {
            return _contentDirectory;
        }
        public Badges GetById(int badgeNumber)
        {
            foreach(Badges content in _contentDirectory)
            {
                if (content.BadgeNumber == badgeNumber)
                {
                    return content;
                }
                else
                {
                    Console.WriteLine("I am sorry but no one could be found by that id");
                }
            }
            return null;
            
        }
        public bool Update(int badgeNumber, Badges newContent)
        {
            Badges oldContent = GetById(badgeNumber);
            if(oldContent != null)
            {
                oldContent.BadgeNumber = newContent.BadgeNumber;
                oldContent.DoorAccess = newContent.DoorAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(Badges existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }

    }
}
