using System;
using System.Collections.Generic;

namespace Order.Management.Reports
{
    class CuttingListReport : Order
    {
        public int tableWidth = 20;
        public CuttingListReport(ICustomer customer)
        {
            this.customer = customer;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(base.ToString());
            generateTable();
        }
        public void generateTable()
        {
            Helpers.PrintLine(tableWidth);
            Helpers.PrintRow(tableWidth,"        ", "   Qty   ");
            Helpers.PrintLine(tableWidth);
            foreach (var shapeType in base.Shapes)
            {
                var shapeName = shapeType.Name;
                var shape = customer.GetShape(shapeName);
                var shapeRecord = new List<string>
                {
                    shapeName,
                    shape.TotalNoOfShapes().ToString()
                };
                Helpers.PrintRow(tableWidth, shapeRecord.ToArray());
            }
            Helpers.PrintLine(tableWidth);
        }
    }
}
