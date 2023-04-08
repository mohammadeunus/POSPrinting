﻿using System;
using System.IO.Ports;
using System.Text;

namespace POSPrinting
{
    class Program
    {
        // Method to print the lines of text to the console
        static void PrintLines(List<string> lines)
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
            ReceiptPrinter printer = new ReceiptPrinter(48, comment);
            List<string> lines = printer.SplitCommentIntoLines();
            PrintLines(lines);
        }
    }
}