using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{

    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
    public class Claim
    {
        public int ClaimId { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public ClaimType ClaimType { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan claimTime = DateOfClaim - DateOfIncident;
                double totalDays = claimTime.Days;
                int days = Convert.ToInt32(totalDays);

                if (days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Claim() { }
        public Claim(int claimId, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, ClaimType claimType)
        {
            ClaimId = claimId;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            ClaimType = claimType;
        }
    }
}
