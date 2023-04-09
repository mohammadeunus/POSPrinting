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
            string foodName = "Pizza";
            string comment = "This pizza was amazing! It was the perfect balance of cheese and sauce, and the crust was just the right amount of crispy.";
            string dateTime = DateTime.Now.ToString("hh:mm:ss tt");
            byte lineSize = 42;
            byte oneThirdOfLineSize = (byte)(lineSize / 3);

            // Create a new instance of the ReceiptPrinter class and call its methods to split and print the comment
            ReceiptPrinter Rcomment = new ReceiptPrinter((byte)lineSize, comment);
            List<string> linesOfComment = Rcomment.SplitCommentIntoLines();
            int commentLineCount = Rcomment.LineSize();

            ReceiptPrinter OFoodName = new ReceiptPrinter(foodName);
            List<string> linesOfFoodName =OFoodName.LineAdd(foodName,48/3, commentLineCount);

            ReceiptPrinter ODate = new ReceiptPrinter(dateTime.ToString());
            List<string> linesOfDate = OFoodName.LineAdd(dateTime.ToString(), 48 / 3, commentLineCount);

            PrintLines(commentLineCount, linesOfFoodName, linesOfComment,linesOfDate);

        }
    }
}
