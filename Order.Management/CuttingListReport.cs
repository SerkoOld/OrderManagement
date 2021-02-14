using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CuttingListReport : Order
    {
        public CuttingListReport(CustomerInfo customerInfo, List<Shape> shapes) : base(customerInfo, shapes)
        {
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
