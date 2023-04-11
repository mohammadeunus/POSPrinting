using System;
using System.IO.Ports;
using System.Text;

namespace POSPrinting
{
    class Program
    {
        // Method to print the lines of text to the console
        static void PrintLines(int LineCount, List<string> linesOfFoodName, List<string> linesOfComment, List<string> linesOfDate)
        {
            for (int i = 0; i < LineCount; i++)
            {
                Console.WriteLine($"{linesOfDate[i]}  {linesOfFoodName[i]}  {linesOfComment[i]}");
            }
        }


        static void Main(string[] args)
        {
            // Get input data from the user
            string foodName = "HamburgerSandwich";
            string comment = "This hamburger sandwich was delicious! Perfectly cooked patty, fresh toppings, and a soft bun made for a great balance of flavors and textures.";
            string dateTime = DateTime.Now.ToString("hh:mm:ss tt");
            byte CharInEachLine = 42;
            byte spaceCountBetweenColumn = 2;


            // Create a new instance of the ReceiptPrinter class and ...
            ReceiptPrinter ORestaurant = new ReceiptPrinter(foodName, comment, dateTime);
            ORestaurant.Modify(CharInEachLine, spaceCountBetweenColumn);
            ORestaurant.PrintLines();

        }
    }
}
