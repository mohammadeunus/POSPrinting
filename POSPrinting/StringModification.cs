using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSPrinting
{
    internal class StringModification // helper class of ReceiptPrinter
    {  
        public StringModification(byte numberOfColumns, byte CharInEachLines) 
        {
            this.numberOfColumns = numberOfColumns;
            this.numberOfCharInEachColumn = (byte)(CharInEachLines/numberOfColumns);
        }

        internal static int highestNumberOfLines { get; set; } = 0;
        private byte numberOfCharInEachColumn { get; set; }
        private byte numberOfColumns { get; set; }


        internal List<string> SplitCommentIntoLines(string ColumnsBody, byte CharInEachLine)
        {
            string[] eachWordInColumnBody = ColumnsBody.Split(' ');
            List<string> lineOfAColumn = new List<string>();

            string currentLine = string.Empty;

            for (int i = 0; i < eachWordInColumnBody.Length; i++)
            {
                if (currentLine.Length + eachWordInColumnBody[i].Length + 1 <= numberOfCharInEachColumn)
                {
                    currentLine += eachWordInColumnBody[i] + " ";
                }
                else
                {
                    lineOfAColumn.Add(currentLine);

                    currentLine = eachWordInColumnBody[i] + " ";
                }
            }
            if (highestNumberOfLines < lineOfAColumn.Count)
            {
                highestNumberOfLines = lineOfAColumn.Count;
            }

            return lineOfAColumn;
        }


        internal void PaddingLinesSpaces(List<List<string>>? columnBodies)
        {
            string currentLine = string.Empty;
            for (int i =0; i< numberOfColumns; i++ ) //numberOfColumns
            {
                columnBodies[i] = addLines(columnBodies[i]);
                
                int spaceCount = numberOfCharInEachColumn - currentLine.Length;
                currentLine += new string(' ', spaceCount);

                columnBodies[i].Add(currentLine.Trim());
            }

            List<string> addLines(List<string> aColumnInList)
            {
                int lineCount = highestNumberOfLines - aColumnInList.Count();
                for(int i = 0;i < lineCount; i++)
                {
                    aColumnInList.Add("");
                }
                return aColumnInList;
            }
        }

    }
}
