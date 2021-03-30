using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CuttingListReport : Order
    {
        private int tableWidth = 20;
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(ToString());
            generateTable();
        }
        public void generateTable()
        {
            PrintLine(new string('-', tableWidth));
            PrintRow("        ", "   Qty   ");
            PrintLine(new string('-', tableWidth));
            PrintRow("Square", OrderedBlocks[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", OrderedBlocks[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", OrderedBlocks[2].TotalQuantityOfShape().ToString());
            PrintLine(new string('-', tableWidth));
        }
        //Consider moving this to the base class 
        

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }


    }
}
