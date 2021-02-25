using Order.Management.Helpers;
using System;
using System.Collections.Generic;

namespace Order.Management
{
    class InvoiceReport : Order
    {
        public const int tableWidth = 73;

        public InvoiceReport(string customerName,
            string customerAddress,
            string dueDate,
            List<Shape> shapes) : base(
            customerName,
            customerAddress,
            dueDate,
            shapes)
        { }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(GenerateOrderInfo());
            GenerateTable();
            OrderShapeDetails();
            RedPaintSurcharge();
        }

        public void RedPaintSurcharge()
        {
            Console.WriteLine(string.Format(
                "Red Color Surcharge       {0} @ ${1} ppi = ${2}",
                TotalAmountOfRedShapes(),
                Shape.RedSurcharge,
                TotalPriceRedPaintSurcharge()
                ));
        }

        public int TotalAmountOfRedShapes()
        {
            var redShapes = 0;

            foreach (Shape shape in OrderedBlocks)
            {
                redShapes += shape.NumberOfRedShape;
            }

            return redShapes;
        }

        private int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * Shape.RedSurcharge;
        }

        private void GenerateTable()
        {
            TableHelper.GenerateTable(tableWidth, OrderedBlocks);
        }

        private void OrderShapeDetails()
        {
            Console.WriteLine();

            foreach(Shape shape in OrderedBlocks)
            {
                Console.WriteLine(string.Format(
                    "{0}s 		  {1} @ ${2} ppi = ${3}",
                    shape.Name,
                    shape.TotalQuantityOfShape(),
                    shape.Price,
                    shape.TotalPrice()
                    ));
            }
        }

    }
}
