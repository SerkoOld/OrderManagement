using System;
using System.Collections.Generic;

namespace Order.Management
{
    abstract class Order : IReport
    {
        public string CustomerName { get; set; }

        public string Address { get; set; }

        protected Order(string customerName, string customerAddress, string dueDate, List<Shape> orderedBlocks)
        {
            CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
            Address = customerAddress ?? throw new ArgumentNullException(nameof(customerAddress));
            DueDate = dueDate ?? throw new ArgumentNullException(nameof(dueDate));
            OrderedBlocks = orderedBlocks ?? throw new ArgumentNullException(nameof(orderedBlocks));
        }

        public string DueDate { get; set; }

        public int OrderNumber { get; set; }

        public List<Shape> OrderedBlocks { get; set; }

        public override string ToString() => $"\nName: {CustomerName} Address: {Address} Due Date: {DueDate} Order #: {OrderNumber:0000}";

        public UInt16 tableWidth = 20;
        public abstract void GenerateReport();
       
        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            return string.IsNullOrEmpty(text) ? new string(' ', width) : text.PadRight(width - ((width - text.Length) / 2)).PadLeft(width);
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += $"{AlignCentre(column, width)}|";
            }

            Console.WriteLine(row);
        }

        public virtual void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", OrderedBlocks[0].NumberOfRedShape.ToString(), OrderedBlocks[0].NumberOfBlueShape.ToString(), OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", OrderedBlocks[1].NumberOfRedShape.ToString(), OrderedBlocks[1].NumberOfBlueShape.ToString(), OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", OrderedBlocks[2].NumberOfRedShape.ToString(), OrderedBlocks[2].NumberOfBlueShape.ToString(), OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
    }
}
