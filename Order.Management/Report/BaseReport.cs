using System;

namespace Order.Management
{
    public abstract class BaseReport
    {
        private int _tableWidth = 73;

        protected readonly Order order;
        protected BaseReport(Order order)
        {
            this.order = order;
        }

        public abstract void GenerateReport();

        protected void SetTableWidth(int width)
        {
            _tableWidth = width;
        }

        protected void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            
            foreach (Enum shape in CommonConst.ShapeList)
            {
                PrintRow(
                    shape,
                    order.GetCountByShapeAndColor(shape, Color.Red),
                    order.GetCountByShapeAndColor(shape, Color.Blue),
                    order.GetCountByShapeAndColor(shape, Color.Yellow)
                );
            }
            PrintLine();
        }

        protected void PrintLine()
        {
            Console.WriteLine(new string('-', _tableWidth));
        }

        protected void PrintRow(params object[] columns)
        {
            int width = (_tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (object column in columns)
            {
                row += AlignCentre(column.ToString(), width) + "|";
            }

            Console.WriteLine(row);
        }

        private string AlignCentre(string text, int width)
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