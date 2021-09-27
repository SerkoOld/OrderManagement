using System;
using System.Collections.Generic;
using Order.Management.Enums;

namespace Order.Management
{
    public abstract class ReportBase
    {
        private int _tableWidth;
        protected readonly Models.Order Order;

        protected ReportBase(Models.Order order)
        {
            Order = order;
            _tableWidth = Constants.TableWidth;
        }

        protected void SetTableWidth(int width)
        {
            _tableWidth = width;
        }

        protected void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            var shapesList = new List<Shapes>()
            {
                Shapes.Square,
                Shapes.Triangle,
                Shapes.Circle,
            };
            foreach (Shapes shape in shapesList)
            {
                PrintRow(
                    shape,
                    Order.GetNumbersOfShapeWithColour(shape, ShapeColours.Red),
                    Order.GetNumbersOfShapeWithColour(shape, ShapeColours.Blue),
                    Order.GetNumbersOfShapeWithColour(shape, ShapeColours.Yellow)
                );
            }
            PrintLine();
        }

        public abstract void GenerateReport();

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