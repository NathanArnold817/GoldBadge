using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgesUI
    {
        protected readonly BadgesRepository _contentDirectory = new BadgesRepository();

        Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
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
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        Update();
                        break;
                    case "3":
                        View();
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 3");
                        ReduceRed();
                        break;
                }
            }
        }
        private void AddBadge()
        {

            Console.Clear();
            Console.WriteLine("What is the number on the badge: ");
            int badgeNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("List a door that it needs access to: ");
            List<string> doorAccess = new List<string> { Console.ReadLine() };
            bool doorWorks = true;
            while (doorWorks == true)
            {
                Console.WriteLine("Any other doors(y/n) ");
                string userAnswer = Console.ReadLine();
                userAnswer = userAnswer.ToLower();

                if (userAnswer == "y")
                {
                    Console.WriteLine("List a door that it needs access to: ");
                    doorAccess.Add(Console.ReadLine());

                }
                else
                {
                    doorWorks = false;
                }
            }
            dict.Add(badgeNumber, doorAccess);
            Badges content = new Badges(badgeNumber, doorAccess);
            _contentDirectory.AddBadge(content);
        }

        private void Update()
        {

            Console.Clear();
            Console.WriteLine("What is the badge number to update? ");
            int answer = int.Parse(Console.ReadLine());
            Badges mvm = _contentDirectory.GetById(answer);

            Console.WriteLine($"{mvm.BadgeNumber} has access to doors{mvm.DoorAccess}");
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    string userA = Console.ReadLine();
                    mvm.DoorAccess.Remove(userA);
                    Console.WriteLine($"{mvm.BadgeNumber} has access to door{mvm.BadgeNumber}.");
                    break;
                case "2":
                    Console.WriteLine("Which door would you like to add?");
                    string userB = Console.ReadLine();
                    mvm.DoorAccess.Add(userB);
                    Console.WriteLine($"{mvm.BadgeNumber} has access to door {mvm.DoorAccess}");
                    break;
            }
        }

        private void ReduceRed()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedList()
        {
            Badges guy1 = new Badges(12345, new List<string>() { "A2", "A4" });
            _contentDirectory.AddBadge(guy1);
            dict.Add(guy1.BadgeNumber, guy1.DoorAccess);
        }
        private void View()
        {
            Console.Clear();
            Console.WriteLine("Key");
            Console.WriteLine("Badge#\t\tDoorAccess");
            
            foreach (KeyValuePair<int, List<string>> kvp in dict)
            {
                Console.Write($"{kvp.Key.ToString()}\t\t");
                foreach (string mvo in kvp.Value)
                {
                    Console.Write($"{mvo},");

                }
                Console.WriteLine("\n");
            }
            ReduceRed();
        }

    }
}
