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
            this.numberOfCharInEachColumn = (byte)(CharInEachLines / numberOfColumns);
        }

        internal static int highestNumberOfLines { get; set; } = 0;
        private byte numberOfCharInEachColumn { get; set; }
        private byte numberOfColumns { get; set; }


        internal List<string> SplitIntoLines(string ColumnsBody, byte CharInEachLine)
        {
            string[] eachWordInColumnBody = ColumnsBody.Split(' ');
            eachWordInColumnBody = CheckLongWord(eachWordInColumnBody);

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
            lineOfAColumn.Add(currentLine.Trim());

            return lineOfAColumn;


        }

        private string[] CheckLongWord(string[] eachWordInColumnBody)
        {
            for (int i = 0; i < eachWordInColumnBody.Length; i++)
            { 
                string t= eachWordInColumnBody[i];
                string t1 = eachWordInColumnBody[i].Substring(0, eachWordInColumnBody[i].Length - eachWordInColumnBody[i].Length / 3);


                if (eachWordInColumnBody[i].Length >= numberOfCharInEachColumn)
                {
                    string test = eachWordInColumnBody[i].Substring(0, eachWordInColumnBody[i].Length - numberOfCharInEachColumn / 3) + new string('.', (numberOfCharInEachColumn / 5));
                    eachWordInColumnBody[i] = test;
                }
            }
            return eachWordInColumnBody;
        }

        internal void PaddingLinesSpaces(List<List<string>> columnBodies)
        {
            for (int i = 0; i < numberOfColumns; i++) //numberOfColumns
            {
                string currentLine = string.Empty;
                List<string> d = columnBodies[i];
                d = addLines(columnBodies[i]);
                for (int j = 0; j < highestNumberOfLines; j++)
                {
                    currentLine = d[j];
                    int spaceCount = numberOfCharInEachColumn - currentLine.Length;
                    currentLine += new string('.', spaceCount);

                    columnBodies[j].Add(currentLine.Trim());
                }
                
            }

            List<string> addLines(List<string> aColumnInList)
            {
                int lineCount = highestNumberOfLines - aColumnInList.Count();
                for (int i = 0; i < lineCount; i++)
                {
                    aColumnInList.Add(".");
                }
                return aColumnInList;
            }
        }

    }
}
