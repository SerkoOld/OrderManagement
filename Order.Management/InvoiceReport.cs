using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Management
{
    internal class InvoiceReport : Order
    {
        public InvoiceReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
            : base(customerName, customerAddress, dueDate, shapes)
        {
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
            Console.WriteLine();

            var shapeTypes = Enum.GetValues(typeof(ShapeTypes)).Cast<ShapeTypes>().ToList();
            foreach (var shapeType in shapeTypes)
            {
                OrderTypeDetails(shapeType);
            }

            VariantSurcharge();
        }

        public void VariantSurcharge()
        {
            Console.WriteLine("Shape Surcharge           " + TotalQtyOfSurchargeShapes() + " @ $" + Constants.AdditionalCharge + " ppi = $" + TotalPriceSurcharge());
        }

        public int TotalQtyOfSurchargeShapes()
        {
            return base.OrderedBlocks.Sum(b => b.AdditionalChargeQty());
        }

        public int TotalPriceSurcharge()
        {
            return OrderedBlocks.Sum(b => b.AdditionalChargeTotal());
        }

        public void GenerateTable()
        {
            ReportHelper.GenerateReport(OrderedBlocks);
        }

        public void OrderTypeDetails(ShapeTypes shapeType)
        {
            Console.WriteLine($"{shapeType.ToString()}s 		  " + OrderedBlocks[(int)shapeType].TotalQuantityOfShape() + " @ $" + OrderedBlocks[(int)shapeType].Price + " ppi = $" + base.OrderedBlocks[(int)shapeType].Total());
        }
    }
}