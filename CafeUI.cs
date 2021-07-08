using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges._01_Cafe
{
   public class CafeUI
    {
        protected readonly MenuRepository _contentDirectory = new MenuRepository();

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
                Console.WriteLine("Enter the number of the option you would like to select: \n" +
                    "1. View menu \n" +
                    "2. Add new menu item \n" +
                    "3. Remove menu item \n" +
                    "4. Exit\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewMenu();
                        break;
                    case "2":
                        Add();
                        break;
                    case "3":
                        Delete();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4");
                        ReduceRed();
                        break;


                }
            }
        }
        private void ViewMenu()
        {
            Console.Clear();
            List<Menu> listOfContent = _contentDirectory.GetContents();
            foreach (Menu content in listOfContent)
            {
                DisplayContent(content);
            }
            ReduceRed();
        }
        private void DisplayContent(Menu content)
        {
            Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                $"Meal Name: {content.MealName}\n" +
                $"Description: {content.Description}\n" +
                $"Ingredients: {content.ListOfIngredients}\n" +
                $"Price: {content.Price}\n");
        }
        private void Add()
        {
            Console.Clear();

            Console.WriteLine("Please enter a meal number: ");
            int mealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a meal name: ");
            string mealName = Console.ReadLine();
            Console.WriteLine("Please enter a description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Please enter ingredients: ");
            string listOfIngredients = Console.ReadLine();
            Console.WriteLine("Please enter a price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Menu content = new Menu(mealNumber,mealName,description,listOfIngredients,price);
            _contentDirectory.Add(content);
        }
        private void Delete()
        {
            Console.Clear();
            List<Menu> listOfContent = _contentDirectory.GetContents();
            Console.WriteLine("What directory number would you like to remove? ");
            foreach (Menu content in listOfContent)
            {
                DisplayContent(content);
            }
            ReduceRed();
            int count = 0;
            List<Menu> contentList = _contentDirectory.GetContents();
            foreach (Menu content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.MealNumber}");
            }
            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            if (targetIndex >= 0 && targetIndex < contentList.Count()) ;
            {
                Menu targetContent = contentList[targetIndex];
                if (_contentDirectory.Delete(targetContent))
                {
                    Console.WriteLine($"{targetContent.MealNumber} removed successfully");
                }
                else
                {
                    Console.WriteLine("Sorry something went wrong item not successfully removed");
                }
            }
        }
        private void GetContentByName()
        {
            Console.Clear();
            Console.WriteLine("What meal Name are you looking for?");
            string mealName = Console.ReadLine();
            Menu content = _contentDirectory.GetContentByName(mealName);

            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("Failed to find a meal with that name");
            }

            ReduceRed();
        }
        private void ReduceRed()
        {
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }
        private void SeedList()
        {
            Menu turkeyAvacodoWrap = new Menu(1, "Turkey Avacodo Wrap", "Delicious", "Stuff and junk", 4.99m);

            _contentDirectory.Add(turkeyAvacodoWrap);
        }
    }
}
