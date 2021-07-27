using Order.Management.Colors;
using System;
using System.Linq;
using System.Text;

namespace Order.Management.Reports
{
    public abstract class BaseReport : IReport
    {
        protected int TableWidth { get; set; }
        protected Order Order { get; }
        public string ReportName { get; set; }

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

        public virtual void GenerateTable()
        {
            PrintLine();

            PrintRow("        ", $"   {nameof(Red)}   ", $"  {nameof(Blue)}  ", $" {nameof(Yellow)} ");
            PrintLine();

            foreach (var groupedOrder in this.Order.OrderedBlocks.GroupBy(o => o.Name))
            {
                var redQuantity = groupedOrder.Where(shape => shape.Color is Red).Sum(o => o.NumberOfShapes);
                var yellowQuantity = groupedOrder.Where(shape => shape.Color is Yellow).Sum(o => o.NumberOfShapes);
                var blueQuantity = groupedOrder.Where(shape => shape.Color is Blue).Sum(o => o.NumberOfShapes);

                PrintRow(groupedOrder.Key, redQuantity.ToString(),
                    blueQuantity.ToString(), yellowQuantity.ToString());
            }

            PrintLine();
        }

        protected void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        protected void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            StringBuilder row = new StringBuilder("|");

            foreach (string column in columns)
            {
                row.Append($"{AlignCentre(column, width)}|");
            }

            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text[..(width - 3)] + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', width)
                : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}
