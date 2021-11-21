using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Report  // Handle common report properties and methods
    {
        private int TableWidth;
        protected Order Order;
        protected string ReportName;
        
        public Report(Order order, string reportName,int tableWidth)
        {
            this.Order = order;
            this.ReportName = reportName;
            this.TableWidth = tableWidth;
        }
        public virtual void GenerateReport()
        {
            Console.WriteLine($"\nYour {this.ReportName} has been generated: ");
            Console.WriteLine(Order.ToString());
            GenerateTable();
        }
        protected virtual void GenerateTable() // Using late binding, because want it call during runtime in the derived class.
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", Order.CustomerInfo.OrderedShape[0].ColorNumbers[Color.Red].ToString(), Order.CustomerInfo.OrderedShape[0].ColorNumbers[Color.Blue].ToString(), Order.CustomerInfo.OrderedShape[0].ColorNumbers[Color.Yellow].ToString());
            PrintRow("Triangle", Order.CustomerInfo.OrderedShape[1].ColorNumbers[Color.Red].ToString(), Order.CustomerInfo.OrderedShape[1].ColorNumbers[Color.Blue].ToString(), Order.CustomerInfo.OrderedShape[1].ColorNumbers[Color.Yellow].ToString());
            PrintRow("Circle", Order.CustomerInfo.OrderedShape[2].ColorNumbers[Color.Red].ToString(), Order.CustomerInfo.OrderedShape[2].ColorNumbers[Color.Blue].ToString(), Order.CustomerInfo.OrderedShape[2].ColorNumbers[Color.Yellow].ToString());
            PrintLine();
        } 

        protected void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        protected void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
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
