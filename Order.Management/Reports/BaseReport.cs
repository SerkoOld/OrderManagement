using System;

namespace Order.Management.Reports
{
    public abstract class BaseReport : IReport
    {
        protected Order Order { get; }
        public string ReportName { get; set; }
        public int TableWidth { get; set; }

        protected BaseReport(Order order)
        {
            Order = order;
        }

        public virtual void GenerateReport()
        {
            Console.WriteLine($"\nYour {ReportName} has been generated: ");
            Console.WriteLine(Order.ToString());

            GenerateTable();
        }

        protected abstract void GenerateTable();

        protected void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        protected void PrintRow(params string[] columns)
        {
            var width = (TableWidth - columns.Length) / columns.Length;
            var row = "|";

            foreach (var column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', width)
                : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}