using System;
using Order.Management.Domain;
using Order.Management.Enums;

namespace Order.Management.Services
{
    public abstract class BaseReport
    {
        private int _tableWidth = 73;
        protected readonly OrderInfo orderInfo;
        protected BaseReport(OrderInfo orderInfo)
        {
            this.orderInfo = orderInfo;
        }

        public abstract void GenerateReport(Enum reportType);

        protected void SetTableWidth(int width)
        {
            _tableWidth = width;
        }

        protected void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();

            foreach (Enum shape in Util.Util.ShapeList)
            {
                PrintRow(
                    shape,
                    orderInfo.GetCountByShapeAndColor(shape, Color.Red),
                    orderInfo.GetCountByShapeAndColor(shape, Color.Blue),
                    orderInfo.GetCountByShapeAndColor(shape, Color.Yellow)
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
                row += AlignCneter(column.ToString(), width) + "|";
            }

            Console.WriteLine(row);
        }

        private string AlignCneter(string text, int width)
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
