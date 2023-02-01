using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Order.Management.Reports
{
    class InvoiceReport : Order
    {
        public int tableWidth = 73;
        public InvoiceReport(ICustomer customer)
        { 
            this.customer = customer;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
            OrderDetails();
            RedPaintSurcharge();
        }

        public void RedPaintSurcharge()
        {
            var shapeAmount = TotalAmountOfRedShapes();
            if (shapeAmount > 0)
            {
                Helpers.PrintRow(tableWidth, new string[] { "Red Color Surcharge", TotalAmountOfRedShapes().ToString(), " @ $" + (ColourConfig.ColoursDict.TryGetValue("Red", out var colourVal) ? colourVal.AdditionalCharge : 0) + " ppi = $" + TotalPriceRedPaintSurcharge() });
            }
        }

        public int TotalAmountOfRedShapes()
        {
            int amount = 0;
            foreach (var shape in base.Shapes)
            {
                var shapeName = shape.Name;
                amount += customer.GetShape(shapeName).ShapeColourCount("Red");
            }
            return amount;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * (ColourConfig.ColoursDict.TryGetValue("Red", out var colourVal) ? colourVal.AdditionalCharge : 0);
        }
        public void GenerateTable()
        {
            Helpers.PrintLine(tableWidth);
            var colours = ColourConfig.Colours;
            colours.ForEach(a =>
            {
                string v = $" {a} ";
            });
            colours.Insert(0, "        ");
            Helpers.PrintRow(tableWidth, colours.ToArray());
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
        public void OrderDetails()
        {
            Console.WriteLine("\nOrder Price structure:\n");
            Helpers.PrintRow(tableWidth, new string[] { "Shape", "Count", "Price" });
            Helpers.PrintLine(tableWidth);    
            foreach (var shape in base.Shapes)
            {
                var shapeName = shape.Name;
                var count = customer.GetShape(shapeName).TotalNoOfShapes();
                var price = customer.GetShape(shapeName).Price;
                var total = customer.GetShape(shapeName).Total();
                Helpers.PrintRow(tableWidth, new string[] { shapeName, count.ToString(), " @ $" + price + " ppi = $" + total });
            }
        }
    }
}
