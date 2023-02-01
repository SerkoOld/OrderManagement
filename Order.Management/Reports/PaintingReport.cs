using System;
using System.Collections.Generic;

namespace Order.Management.Reports
{
    class PaintingReport : Order
    {
        public int tableWidth = 73;
        public PaintingReport(ICustomer customer)
        {
            this.customer = customer;
        }
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(base.ToString());
            generateTable();
        }

        public void generateTable()
        {
            Helpers.PrintLine(tableWidth);
            var colours = ColourConfig.Colours;
            Helpers.PrintRow(tableWidth,colours.ToArray());
            Helpers.PrintLine(tableWidth);
            foreach (var shapeType in base.Shapes)
            {
                var shapeName = shapeType.Name;
                var shape = customer.GetShape(shapeName);
                var shapeRecord = new List<string> { shapeName };
                foreach (var colour in ColourConfig.Colours)
                {
                    if (!string.IsNullOrWhiteSpace(colour))
                    {
                        shapeRecord.Add(shape.ShapeColourCount(colour).ToString());
                    }
                }
                Helpers.PrintRow(tableWidth, shapeRecord.ToArray());
            }
            Helpers.PrintLine(tableWidth);
        }
    }
}
