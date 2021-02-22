using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        public int OrderNumber { get; set; }
        public List<Shape> OrderedBlocks { get; set; }

        public int ReportTableWidth { get; set; }

        public abstract void GenerateReport();

        public void GenerateReportDetail(params string[] reportDetailColumns)
        {
            PrintLine();
            PrintRow(reportDetailColumns);
            PrintLine();
            foreach (var orderedblock in OrderedBlocks)
            {
                PrintRow(orderedblock.Name, orderedblock.NumberOfRedShape.ToString(), orderedblock.NumberOfBlueShape.ToString(), orderedblock.NumberOfYellowShape.ToString());
            }
            PrintLine();
        }

        public string ReportSummaryHeader()
        {
            return string.Format("\nName: {0} Address: {1} Due Date: {2} Order #: {3} ", CustomerName, Address, DueDate, OrderNumber);
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', ReportTableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (ReportTableWidth - columns.Length) / columns.Length;
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
