using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSPrinting
{
    // Define a new class to encapsulate the functionality of the program
    internal class ReceiptPrinter
    {
        // Define class-level fields to store line size and comment data
        private byte lineSize;
        private string comment;

        // Constructor for the ReceiptPrinter class, which takes in the line size and comment data
        public ReceiptPrinter(byte lineSize, string comment)
        {
            this.lineSize = lineSize;
            this.comment = comment;
        }

        // Method to split the comment into lines that fit within the specified line size
        public List<string> SplitCommentIntoLines()
        {
            // Split the comment into an array of words
            string[] commentArray = comment.Split(' ');

            // Calculate the maximum number of words that can fit on a single line
            byte oneThirdOfLineSize = (byte)(lineSize / 3);

            // Create a list to store the lines of text
            List<string> lines = new List<string>();

            // Initialize the first line
            string currentLine = string.Empty;

            // Loop through the words in the comment array and append them to the appropriate line
            for (int i = 0; i < commentArray.Length; i++)
            {
                // If the current word can fit on the current line, append it
                if (currentLine.Length + commentArray[i].Length + 1 <= oneThirdOfLineSize)
                {
                    // Add the current word and a space to the current line
                    currentLine += commentArray[i] + " ";
                }
                // If the current word can't fit on the current line, add the current line to the list and start a new line
                else
                {
                    // Add the current line to the list
                    lines.Add(currentLine.Trim());

                    // Start a new line with the current word and a space
                    currentLine = commentArray[i] + " ";
                }
            }

            // Add the last line to the list
            lines.Add(currentLine.Trim());

            return lines;
        }
    }
}
