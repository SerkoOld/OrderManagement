using System;
using Order.Management.Enums;

namespace Order.Management
{
    class InvoiceReport : ReportBase
    {
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(Order.ToString());
            GenerateTable();
            Console.WriteLine();
            ShowOrderDetailsInShape();
            ShowRedPaintSurcharge();
        }

        private void ShowOrderDetailsInShape()
        {
            foreach (var shape in Constants.CurrentShapes)
            {
                PrintOrderDetailsByShape(shape);
            }
        }

        private void ShowRedPaintSurcharge()
        {
            Console.WriteLine(
                $"Red Color Surcharge       {Order.GetNumbersOfColour(ShapeColours.Red)} @ ${Constants.AdditionalCharge} ppi = ${Order.RedPaintSurcharge}");
        }

        private void PrintOrderDetailsByShape(Shapes shape)
        {
            Console.WriteLine(
                $"{shape}s 		  {Order.GetNumbersOfShape(shape)} @ ${shape.GetUnitPrice()} ppi = ${Order.GetPriceTotalByShape(shape)}");
        }

        public InvoiceReport(Models.Order order) : base(order)
        {
        }
    }
}