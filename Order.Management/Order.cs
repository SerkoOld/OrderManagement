using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Order
    {
        CustomerInfo CustomerInfo { get; set; }
        public int OrderNumber { get; private set; }
        public List<Shape> OrderedBlocks { get; private set; }

        public Order(CustomerInfo customerInfo, List<Shape> shapes) 
        {
            CustomerInfo = customerInfo;
            OrderedBlocks = shapes;
        }

        #region Abstract Methods
        public virtual void GenerateTable()
        {
            PrintLine();
            PrintRow(new List<string>
                {
                    "        ", 
                    "   Red   ", 
                    "  Blue  ", 
                    " Yellow "
                });
            PrintLine();   
            foreach(var order in OrderedBlocks)
            {
                PrintRow(new List<string>
                {
                    order.Name,
                    order.NumberOfRedShape.ToString(),
                    order.NumberOfBlueShape.ToString(),
                    order.NumberOfYellowShape.ToString()
                });
            }           
            PrintLine();
        }

        #endregion

        #region Abstract Properties

        public virtual int TableWidth => 73;
        public abstract string ReportType { get; }
        #endregion

        #region Protected/Private Methods

        public virtual void GenerateReport()
        {
            ReportHeader(ReportType);
            GenerateTable();
        }

        protected void PrintRow(List<string> columns)
        {
            int width = (TableWidth - columns.Count) / columns.Count;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private string CustomerDetails()
        {
            return "\nName: " + CustomerInfo.CustomerName + " Address: " + CustomerInfo.Address + " Due Date: " + CustomerInfo.DueDate + " Order #: " + OrderNumber;
        }

        protected void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        protected void ReportHeader(string reportType)
        {
            Console.WriteLine("\nYour {0} report has been generated: ", ReportType);
            Console.WriteLine(CustomerDetails());
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

        #endregion
    }
}
