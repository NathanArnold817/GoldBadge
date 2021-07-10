using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimRepository
    {
        protected readonly List<Claim> _contentDirectory = new List<Claim>();

        public bool Add(Claim newContent)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(newContent);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }


        public List<Claim> ViewAllClaims()
        {
            return _contentDirectory;
        }
        public List<Claim> TakeCareOfNextClaim()
        {
            return _contentDirectory;
        }
    }
}

