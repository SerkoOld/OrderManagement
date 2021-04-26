using System;

namespace Order.Management.Reports
{
    class InvoiceReport : BaseReport
    {
        protected override int TableWidth => 73;
        OrderDetails.Order _order;

        public InvoiceReport(OrderDetails.Order order)
        {
            _order = order;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(_order.PrintOrderDetails());
            GenerateTable();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        private void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + _order.OrderedBlocks[0].RedColorSurcharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        private int TotalAmountOfRedShapes()
        {
            return _order.OrderedBlocks[0].NumberOfRedShape + _order.OrderedBlocks[1].NumberOfRedShape +
                   _order.OrderedBlocks[2].NumberOfRedShape;
        }

        private int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * _order.OrderedBlocks[0].RedColorSurcharge;
        }
        private void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", _order.OrderedBlocks[0].NumberOfRedShape.ToString(), _order.OrderedBlocks[0].NumberOfBlueShape.ToString(), _order.OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", _order.OrderedBlocks[1].NumberOfRedShape.ToString(), _order.OrderedBlocks[1].NumberOfBlueShape.ToString(), _order.OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", _order.OrderedBlocks[2].NumberOfRedShape.ToString(), _order.OrderedBlocks[2].NumberOfBlueShape.ToString(), _order.OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
        private void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + _order.OrderedBlocks[0].TotalQuantityOfShape() + " @ $" + _order.OrderedBlocks[0].Price + " ppi = $" + _order.OrderedBlocks[0].Total());
        }
        private void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + _order.OrderedBlocks[1].TotalQuantityOfShape() + " @ $" + _order.OrderedBlocks[1].Price + " ppi = $" + _order.OrderedBlocks[1].Total());
        }
        private void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + _order.OrderedBlocks[2].TotalQuantityOfShape() + " @ $" + _order.OrderedBlocks[2].Price + " ppi = $" + _order.OrderedBlocks[2].Total());
        }
    }
}
