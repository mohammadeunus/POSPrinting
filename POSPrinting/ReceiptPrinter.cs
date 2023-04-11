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
        private byte charInEachLine { get; set; }
        private byte spaceCountBetweenColumn { get; set; }
        public string[] columnsBody { get; set; }
        private List<string> lines { get; set; }
        private int numberOfColumn { get; set; }


        // Constructor for the ReceiptPrinter class, which takes in the line size and comment data
        public ReceiptPrinter(params string[] columnsBody)
        {
            this.columnsBody = columnsBody;
            this.numberOfColumn =  columnsBody.Count<string>();

        }
        internal void Modify(byte charInEachLine, byte spaceCountBetweenColumn)
        {
            this.charInEachLine= charInEachLine;
            this.spaceCountBetweenColumn= spaceCountBetweenColumn;
        }

        internal void PrintLines()
        {
            Console.WriteLine(numberOfColumn);
        }
    }
}
