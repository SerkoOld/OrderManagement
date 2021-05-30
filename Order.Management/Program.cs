using System;
using System.Collections.Generic;
using Order.Management.Colors;
using Order.Management.Reports;
using Order.Management.Shapes;

namespace Order.Management
{
    class Program
    {
        // Main entry
        static void Main(string[] args)
        {
            var customerInfo = CustomerInfoInput();

            var orderedShapes = CustomerOrderInput();

            var order = new Order("0001", customerInfo, orderedShapes);

            Console.WriteLine();
            InvoiceReport(order);

            CuttingListReport(order);

            PaintingReport(order);
        }

        // Order Squares Input
        private static IEnumerable<IShape> OrderInput<T>(string shapeName) where T : IShape
        {
            var shapes = new List<IShape>();

            Console.Write($"\nPlease input the number of Red {shapeName}s: ");
            var redShapeQuantity = Convert.ToInt32(UserInput());
            var redShape = ShapeFactory.Create<T>(new Red(), redShapeQuantity);
            shapes.Add(redShape);

            Console.Write($"Please input the number of Blue {shapeName}s: ");
            var blueShapeQuantity = Convert.ToInt32(UserInput());
            var blueShape = ShapeFactory.Create<T>(new Blue(), blueShapeQuantity);
            shapes.Add(blueShape);

            Console.Write($"Please input the number of Yellow {shapeName}s: ");
            var yellowShapeQuantity = Convert.ToInt32(UserInput());
            var yellowShape = ShapeFactory.Create<T>(new Yellow(), yellowShapeQuantity);
            shapes.Add(yellowShape);

            return shapes;
        }

        // User Console Input
        // TODO: validations for user input should be required
        private static string UserInput()
        {
            var input = Console.ReadLine();
            // If whitespace is allowed, empty or null maybe also allowable
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();
            }

            return input;
        }

        // Generate Painting Report 
        private static void PaintingReport(Order order)
        {
            var paintingReport = new PaintingReport(order);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void CuttingListReport(Order order)
        {
            var cuttingListReport = new CuttingListReport(order);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void InvoiceReport(Order order)
        {
            var invoiceReport = new InvoiceReport(order);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static CustomerInfo CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            var customerName = UserInput();
            Console.Write("Please input your Address: ");
            var address = UserInput();
            Console.Write("Please input your Due Date: ");
            var dueDate = UserInput();
            return new CustomerInfo(customerName, address, dueDate);
        }

        // Get order input
        private static List<IShape> CustomerOrderInput()
        {
            var squares = OrderInput<Square>(nameof(Square));

            var triangles = OrderInput<Triangle>(nameof(Triangle));

            var circles = OrderInput<Circle>(nameof(Circle));

            var orderedShapes = new List<IShape>();
            orderedShapes.AddRange(squares);
            orderedShapes.AddRange(triangles);
            orderedShapes.AddRange(circles);
            return orderedShapes;
        }
    }
}