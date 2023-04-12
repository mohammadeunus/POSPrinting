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
        public byte charInEachColumn { get; set; }
        private byte spaceCountBetweenColumn { get; set; } = 2;
        public List<List<string>> columnBodies { get; set; }
        private byte numberOfColumn { get; set; }


        // Constructor for the ReceiptPrinter class, which takes in the line size and comment data
        public MakeALine(params string[] columnsBody)
        {
            this.numberOfColumn = (byte)columnsBody.Count<string>();
            charInEachColumn = (byte)(charInEachLine / numberOfColumn);

            StringModification OStringModification = new StringModification(numberOfColumn, charInEachColumn);
            for (int i = 0; i < numberOfColumn; i++)
            {
                columnBodies.Add(OStringModification.SplitCommentIntoLines(columnsBody[i], charInEachLine));
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
                    completeLine = ($"{columnBodies[0][i]}{space}");
                }
                Console.WriteLine(completeLine.Trim());
            }

        }
    }
}
