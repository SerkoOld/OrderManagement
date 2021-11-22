using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class ReportBase  // Handle common report properties and methods
    {
        private int _tableWidth;
        protected Order _order;
        protected string _reportName;
        
        public ReportBase(Order order, string reportName,int tableWidth)
        {
            this._order = order;
            this._reportName = reportName;
            this._tableWidth = tableWidth;
        }
        public virtual void GenerateReport()
        {
            Console.WriteLine($"\nYour {this._reportName} has been generated: ");
            Console.WriteLine(_order.ToString());
            GenerateTable();
        }
        protected virtual void GenerateTable() // Using late binding, because want it call during runtime in the derived class.
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", _order.CustomerInfo.OrderedShape[0].ColorNumbers[Color.Red].ToString(), _order.CustomerInfo.OrderedShape[0].ColorNumbers[Color.Blue].ToString(), _order.CustomerInfo.OrderedShape[0].ColorNumbers[Color.Yellow].ToString());
            PrintRow("Triangle", _order.CustomerInfo.OrderedShape[1].ColorNumbers[Color.Red].ToString(), _order.CustomerInfo.OrderedShape[1].ColorNumbers[Color.Blue].ToString(), _order.CustomerInfo.OrderedShape[1].ColorNumbers[Color.Yellow].ToString());
            PrintRow("Circle", _order.CustomerInfo.OrderedShape[2].ColorNumbers[Color.Red].ToString(), _order.CustomerInfo.OrderedShape[2].ColorNumbers[Color.Blue].ToString(), _order.CustomerInfo.OrderedShape[2].ColorNumbers[Color.Yellow].ToString());
            PrintLine();
        } 

        protected void PrintLine()
        {
            Console.WriteLine(new string('-', _tableWidth));
        }

        protected void PrintRow(params string[] columns)
        {
            int width = (_tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        protected string AlignCentre(string text, int width)
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
