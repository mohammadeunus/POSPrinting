using System;
using System.IO.Ports;
using System.Text;

namespace POSPrinting
{
    class Program
    {
        // Method to print the lines of text to the console
        static void PrintLines(params List<string>[] lists)
        {
            Console.WriteLine(lines.Count);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        static void Main(string[] args)
        {
            // Get input data from the user
            string foodName = "Pizza";
            string comment = "This pizza was amazing! It was the perfect balance of cheese and sauce, and the crust was just the right amount of crispy.";
            DateTime dateTime = DateTime.Now;

            // Create a new instance of the ReceiptPrinter class and call its methods to split and print the comment
            ReceiptPrinter Rcomment = new ReceiptPrinter((byte)48, comment);
            List<string> linesOfComment = Rcomment.SplitCommentIntoLines();
            int commentLineCount = Rcomment.LineSize();

            List<string> linesOfFoodName = new ReceiptPrinter(foodName).SplitCommentIntoLines();

            PrintLines(linesOfComment, linesOfFoodName);

        }
    }
}
