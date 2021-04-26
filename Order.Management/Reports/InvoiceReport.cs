using Order.Management.Shapes;
using System;

namespace Order.Management.Reports
{
    class InvoiceReport : IReport
    {
        private const int FirstColumnWidth = 25;
        private const int SecondColumnWidth = 15;
        private const int TableWidth = 73;
        private readonly OrderDetails.Order _order;
        private readonly ReportHelper _printReportHelper;

        private readonly Square _square;
        private readonly Triangle _triangle;
        private readonly Circle _circle;

        public InvoiceReport(OrderDetails.Order order)
        {
            _order = order ?? throw new ArgumentNullException(nameof(order));
            _square = order.Square ?? throw new ArgumentNullException(nameof(order.Square));
            _triangle = order.Triangle ?? throw new ArgumentNullException(nameof(order.Triangle));
            _circle = order.Circle ?? throw new ArgumentNullException(nameof(order.Circle));
            _printReportHelper = new ReportHelper(TableWidth);
        }

        public void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(_order.PrintOrderDetails());
            GenerateTable();
            Console.WriteLine();
            OrderShapeDetails(_square);
            OrderShapeDetails(_triangle);
            OrderShapeDetails(_circle);
            RedPaintSurcharge();
            _printReportHelper.PrintLine();
            PrintTotal();
        }

        private void GenerateTable()
        {
            _printReportHelper.PrintLine();
            _printReportHelper.PrintRow("", "Red", "Blue", "Yellow");
            _printReportHelper.PrintLine();
            PrintShapeInformationRow(_square);
            PrintShapeInformationRow(_triangle);
            PrintShapeInformationRow(_circle);
            _printReportHelper.PrintLine();
        }

        private void PrintShapeInformationRow(Shape shape)
        {
            _printReportHelper.PrintRow(shape.Name.ToString(), shape.NumberOfRedShape.ToString(), shape.NumberOfBlueShape.ToString(), shape.NumberOfYellowShape.ToString());
        }

        private void OrderShapeDetails(Shape shape)
        {
            var firstColumnValue = shape.Name;
            var secondColumnValue = $"{shape.TotalQuantityOfShape()} @ {shape.Price:C} ppi = ";
            Console.WriteLine($"{firstColumnValue,-FirstColumnWidth}{secondColumnValue,-SecondColumnWidth}{shape.Total():C}");
        }

        private void RedPaintSurcharge()
        {
            var firstColumnValue = "Red Color Surcharge";
            var secondColumnValue = $"{TotalAmountOfRedShapes()} @ {Shape.RedColorSurcharge:C} ppi = ";
            Console.WriteLine($"{firstColumnValue,-FirstColumnWidth}{secondColumnValue,-SecondColumnWidth}{TotalPriceRedPaintSurcharge():C}");
        }

        private int TotalAmountOfRedShapes()
        {
            return _square.NumberOfRedShape + _triangle.NumberOfRedShape + _circle.NumberOfRedShape;
        }

        private decimal TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * Shape.RedColorSurcharge;
        }

        private void PrintTotal()
        {
            var firstColumnValue = "Total:";
            const int firstAndSecondColumnWidth = FirstColumnWidth + SecondColumnWidth;
            Console.WriteLine($"{firstColumnValue,-firstAndSecondColumnWidth} {_order.Total():C}");
        }
    }
}
