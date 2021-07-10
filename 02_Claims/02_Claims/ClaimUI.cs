using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    class ClaimUI
    {
        protected readonly ClaimRepository _contentDirectory = new ClaimRepository();
        Queue<Claim> myQueue = new Queue<Claim>();
        public void Run()
        {
            SeedList();
            DisplayMenu();
        }
        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item: \n" +
                    "1.See all claims  \n" +
                    "2.Take care of next claim \n" +
                    "3.Enter a new claim \n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 3");
                        ReduceRed();
                        break;


                }
            }
        }
        private void ViewAllClaims()
        {
            Console.Clear();
            List<Claim> listOfContent = _contentDirectory.ViewAllClaims();
            //0 selects first in list second 0 selects number of spaces item to write goes
            // "{0,0}{1,10}{2,16}{3,21}{4,26}{5,20}{6,15}"
            Console.WriteLine("Claim Id\tType\t\tDescription\tAmount\t\tDateOfAccident\tDateOfClaim\tIsVaild");
            foreach (Claim content in listOfContent)
            {
                DisplayContent(content);
            }
            ReduceRed();
        }
        private void DisplayContent(Claim content)
        {
            Console.WriteLine($"{content.ClaimId}\t\t{content.ClaimType}\t\t{content.Description}\t{content.ClaimAmount}\t\t{content.DateOfIncident.ToString("MM/dd/yyyy")}\t{content.DateOfClaim.ToString("MM/dd/yyyy")}\t{content.IsValid}");
        }
        private void TakeCareOfNextClaim()
        {

            List<Claim> listOfContent = _contentDirectory.TakeCareOfNextClaim();
            foreach (Claim content in listOfContent)
            {

                myQueue.Peek();
                Console.Clear();
                Console.WriteLine("Here are the details for the next claim to be handled:");
                Console.WriteLine($"ClaimID:{content.ClaimId}\n" +
                    $"Type:{content.ClaimType}\n" +
                    $"Description:{content.Description}\n" +
                    $"Amount:{content.ClaimAmount}\n" +
                    $"DateOfAccident:{content.DateOfIncident.ToString("MM/dd/yyyy")}\n" +
                    $"DateOfClaim:{content.DateOfClaim.ToString("MM/dd/yyyy")}\n" +
                    $"IsValid:{content.IsValid}");

            }
            Console.WriteLine("Do you want to deal with this claim now?\n" +
                "1. Yes \n" +
                "2. No");
            string yesOrNO = Console.ReadLine();

            switch (yesOrNO)
            {
                case "1":
                    myQueue.Dequeue();
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Please select 1 or 2");
                    ReduceRed();
                    break;
            }

        }
        private void EnterANewClaim()
        {
            Console.Clear();
            Console.WriteLine("Please enter the claim id: ");
            int claimId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please select a claim type: \n" +
                "0. Car\n" +
                "1. Home\n" +
                "2. Theft");
            string sClaimType = Console.ReadLine();
            ClaimType claimType;
            claimType = (ClaimType)int.Parse(sClaimType);
            Console.WriteLine("Please enter a Claim Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Please enter the amount of damage: ");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date of incident: ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date of the claim: ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());
            Claim content = new Claim(claimId, description, claimAmount, dateOfIncident, dateOfClaim, claimType);
            _contentDirectory.Add(content);
            myQueue.Enqueue(content);
        }
        private void ReduceRed()
        {
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }
        private void SeedList()
        {
            Claim terribleAccident = new Claim(1, "Not Good!", 5540.00m, new DateTime(2021, 07, 04), new DateTime(2021, 07, 05), ClaimType.Home);
            Claim horribleTragedy = new Claim(2, "Really Bad!", 550.00m, new DateTime(2021, 04, 27), new DateTime(2021, 07, 06), ClaimType.Theft);
            _contentDirectory.Add(terribleAccident);
            myQueue.Enqueue(terribleAccident);
            _contentDirectory.Add(horribleTragedy);
            myQueue.Enqueue(horribleTragedy);
        }
    }
}