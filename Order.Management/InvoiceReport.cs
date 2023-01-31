using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Management
{
    class InvoiceReport : Order
    {
        public int tableWidth = 73;
        public InvoiceReport(Customer customer)
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
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + base.customer.GetShape("Circle").AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            int amount = 0;
            foreach (var shape in customer.Shapes)
            {
                var shapeName = shape.Name;
                amount += customer.GetShape(shapeName).ShapeColourCount("Red");
            }
            return amount;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * base.customer.GetShape("Circle").AdditionalCharge;
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
            foreach (var shapeType in customer.Shapes)
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
            int rowWidth = 73;
            Console.WriteLine("\n");
            foreach (var shape in customer.Shapes)
            {
                var shapeName = shape.Name;
                var count = customer.GetShape(shapeName).TotalNoOfShapes();
                var price = customer.GetShape(shapeName).Price;
                var total = customer.GetShape(shapeName).Total();
                Console.WriteLine($"{shapeName} 		  " + count + " @ $" + price + " ppi = $" + total);
            }
        }
    }
}
