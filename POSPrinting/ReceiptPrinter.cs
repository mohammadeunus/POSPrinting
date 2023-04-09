using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSPrinting
{
    internal class ReceiptPrinter
    {
        // Define class-level fields to store line size and comment data
        private byte lineSize;
        private string comment;
        private List<string> lines = new List<string>();

        // Constructor for the ReceiptPrinter class, which takes in the line size and comment data
        public ReceiptPrinter(byte lineSize, string comment)
        {
            this.lineSize = lineSize;
            this.comment = comment;
        }
        public ReceiptPrinter(string comment)
        {
            this.lineSize = lineSize;
            this.comment = comment;
        }


        // Method to split the comment into lines that fit within the specified line size
        public List<string> SplitCommentIntoLines()
        {
            string[] commentArray = comment.Split(' ');

            byte oneThirdOfLineSize = (byte)(lineSize / 3);


            string currentLine = string.Empty;

            for (int i = 0; i < commentArray.Length; i++)
            {
                if (currentLine.Length + commentArray[i].Length + 1 <= oneThirdOfLineSize)
                {
                    currentLine += commentArray[i] + " ";
                }
                else
                {

                    int spaceCount = oneThirdOfLineSize - currentLine.Length;
                    currentLine += new string('_', spaceCount);
                    lines.Add(currentLine);

                    currentLine = commentArray[i] + " ";
                }
            }
            int spaceCount1 = oneThirdOfLineSize - currentLine.Length;
            currentLine += new string('_', spaceCount1);

            lines.Add(currentLine.Trim());

            return lines;
        }

        public int LineSize()
        {
            return lines.Count;
        }


    }
}
