using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges._01_Cafe
{
   public class MenuRepository
    {
        protected readonly List<Menu> _contentDirectory = new List<Menu>();
        public bool Add(Menu newContent)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(newContent);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Menu> GetContents()
        {
            return _contentDirectory;
        }
        public Menu GetContentByName(string mealName)
        {
            foreach (Menu content in _contentDirectory)
            {
                if (content.MealName.ToLower() == mealName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
        public bool Delete(Menu existingItems)
        {
            bool deleteResult = _contentDirectory.Remove(existingItems);
            return deleteResult;
        }
    }
}
