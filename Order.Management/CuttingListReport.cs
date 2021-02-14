using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CuttingListReport : Order
    {
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
        }

        public override int TableWidth => 20;

        public override string ReportType => "Cutting List";

        public override void  GenerateTable()
        {
            PrintLine();
            PrintRow(new List<string> {
                "        ", 
                "   Qty   " 
            });
            PrintLine();
            foreach (var order in OrderedBlocks)
            {
                PrintRow(new List<string>
                {
                    order.Name,
                    order.TotalQuantity.ToString(),
                });
            }

            PrintLine();
        }
    }
}
