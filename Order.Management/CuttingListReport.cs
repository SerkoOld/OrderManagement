using System;
using System.Collections.Generic;
using Order.Management.Enums;

namespace Order.Management
{
    class CuttingListReport : ReportBase
    {
        public override void GenerateReport()
        {
            SetTableWidth(Constants.CuttingReportTableWidth);
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(Order.ToString());
            GenerateTable();
        }

        private new void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();

            var shapesList = new List<Shapes>()
            {
                Shapes.Square,
                Shapes.Triangle,
                Shapes.Circle,
            };
            foreach (Shapes shape in shapesList)
            {
                PrintRow( shape, Order.GetNumbersOfShape(shape));
            }
            PrintLine();
        }

        public CuttingListReport(Models.Order order) : base(order)
        {
        }
    }
}
