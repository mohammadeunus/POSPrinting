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
        private byte lineSize = 48; //by default
        private byte spaceBetweenColumn = 2; //by default

        private string comment;
        private List<string> lines = new List<string>();
        private int lineCount = 0;

        // Constructor for the ReceiptPrinter class, which takes in the line size and comment data
        public ReceiptPrinter(string comment)
        { 
            this.comment = comment;
        }

        public void modify(byte lineSize, byte spaceBetweenColumn)
        {
            this.lineSize = lineSize;
            this.spaceBetweenColumn = spaceBetweenColumn;
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
                    currentLine += new string(' ', spaceCount);
                    lines.Add(currentLine);

                    currentLine = commentArray[i] + " ";
                }
            }
            int spaceCount1 = oneThirdOfLineSize - currentLine.Length;
            currentLine += new string(' ', spaceCount1);

            lines.Add(currentLine.Trim());

            lineCount = lines.Count;
            
            return lines;
        }
 

        internal List<string> LineAdd(string sample, int oneThirdOfLineSize, int lineCount)
        {
            List<string> lines = new List<string>();

            lines.Add(sample);

            for (int i = 0; i < lineCount - 1; i++)
            {
                lines.Add(" ");
            } 

            for (int i = 0; i < lines.Count; i++)
            {
                int spaceCount = oneThirdOfLineSize - lines[i].Length;
                lines[i] += new string(' ', spaceCount);
            }

            return lines;
        }

        public int LineSize()
        {
            return lines.Count;
        }
    }
}
