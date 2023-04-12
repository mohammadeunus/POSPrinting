using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSPrinting
{
    internal class MakeALine
    {
        // Define class-level fields to store line size and comment data
        private byte charInEachLine { get; set; } = 48;
        private byte spaceCountBetweenColumn { get; set; } = 2;
        public List<List<string>> columnBodies { get; set; } = new List<List<string>>();
        private byte numberOfColumn { get; set; }


        // Constructor for the ReceiptPrinter class, which takes in the line size and comment data
        public MakeALine(params string[] columnsBody)
        {
            this.numberOfColumn = (byte)columnsBody.Count<string>();

            StringModification OStringModification = new StringModification(numberOfColumn, charInEachLine);
            for (int i = 0; i < numberOfColumn; i++)
            {
                string column = columnsBody[i];
                List<string> aColumnBody = OStringModification.SplitIntoLines(column, charInEachLine);
                columnBodies.Add(aColumnBody);
            }
            OStringModification.PaddingLinesSpaces(columnBodies);


        }
        internal void Modify(byte charInEachLine, byte spaceCountBetweenColumn)
        {
            this.charInEachLine = charInEachLine;
            this.spaceCountBetweenColumn = spaceCountBetweenColumn;
        }

        internal void PrintLines()
        {
            string space = "";
            for (int i = 0; i < spaceCountBetweenColumn; i++)
            {
                space += " ";
            }

            for (int i = 0; i < StringModification.highestNumberOfLines; i++)
            {
                string completeLine = "";
                foreach (var column in columnBodies)
                {
                    completeLine += ($"{column[i]}{space}");
                }
                Console.WriteLine(completeLine.Trim());
                completeLine = "";
            }

        }
    }
}
