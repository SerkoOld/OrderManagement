using System;

namespace Order.Management
{
    class InvoiceReport : BaseReport
    {
        public InvoiceReport(Order order) : base(order)
        {
        }

        public override void GenerateReport()
        {
            try
            { 
                Console.WriteLine("\nYour invoice report has been generated: ");
                Console.WriteLine(order.ToString());
                GenerateTable();
                Console.WriteLine();
                ShowOrderDetailsByShape();
                ShowRedColorSurcharge();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nPrint invoice report exception: " + ex.Message.ToString());
            }
        }

        private void ShowOrderDetailsByShape()
        {
            foreach (var shape in CommonConst.ShapeList)
            {
                int shapeNumber = order.GetCountByShape(shape);
                decimal unitPrice = order.GetShapePrice(shape);
                Console.WriteLine(
                    $"{shape}s 		  {shapeNumber} @ ${unitPrice} ppi = ${shapeNumber * unitPrice}");
            }
        }

        private void ShowRedColorSurcharge()
        {
            int RedColorNumber = order.GetCountByColor(Color.Red);
            Console.WriteLine(
                    $"Red Color Surcharge       {order.GetCountByColor(Color.Red)} @ ${CommonConst.RedAdditionalCharge} ppi = ${RedColorNumber * CommonConst.RedAdditionalCharge}");
        }
    }
}
