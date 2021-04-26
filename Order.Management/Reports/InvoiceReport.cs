using Order.Management.Shapes;
using System;

namespace Order.Management.Reports
{
    class InvoiceReport : BaseReport
    {
        const int FirstColumnWidth = 25;
        private readonly OrderDetails.Order _order;

        private readonly Square _square;
        private readonly Triangle _triangle;
        private readonly Circle _circle;

        protected override int TableWidth => 73;

        public InvoiceReport(OrderDetails.Order order)
        {
            _order = order ?? throw new ArgumentNullException(nameof(order));
            _square = order.Square ?? throw new ArgumentNullException(nameof(order.Square));
            _triangle = order.Triangle ?? throw new ArgumentNullException(nameof(order.Triangle));
            _circle = order.Circle ?? throw new ArgumentNullException(nameof(order.Circle));
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(_order.PrintOrderDetails());
            GenerateTable();
            Console.WriteLine();
            OrderShapeDetails(_square);
            OrderShapeDetails(_triangle);
            OrderShapeDetails(_circle);
            RedPaintSurcharge();
        }

        private void GenerateTable()
        {
            PrintLine();
            PrintRow("", "Red", "Blue", "Yellow");
            PrintLine();
            PrintShapeInformationRow(_square);
            PrintShapeInformationRow(_triangle);
            PrintShapeInformationRow(_circle);
            PrintLine();
        }

        private void PrintShapeInformationRow(Shape shape)
        {
            PrintRow(shape.Name.ToString(), shape.NumberOfRedShape.ToString(), shape.NumberOfBlueShape.ToString(), shape.NumberOfYellowShape.ToString());
        }

        private void OrderShapeDetails(Shape shape)
        {
            Console.WriteLine($"{shape.Name,-FirstColumnWidth}" + shape.TotalQuantityOfShape() + " @ $" + shape.Price + " ppi = $" + shape.Total());
        }

        private void RedPaintSurcharge()
        {
            var firstColumnValue = "Red Color Surcharge";
            Console.WriteLine($"{firstColumnValue,-FirstColumnWidth}" + TotalAmountOfRedShapes() + " @ $" + Shape.RedColorSurcharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        private int TotalAmountOfRedShapes()
        {
            return _square.NumberOfRedShape + _triangle.NumberOfRedShape + _circle.NumberOfRedShape;
        }

        private int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * Shape.RedColorSurcharge;
        }
    }
}
