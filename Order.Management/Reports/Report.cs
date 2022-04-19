using System;
namespace Order.Management.Reports
{
    public abstract class Report
    {
        public int TableWidth { get; }

        public Order Order { get; }

        public Report(Order order, int tableWidth)
        {
            Order = order;
            TableWidth = tableWidth;
        }

        public abstract void GenerateReport();


        public void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
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
