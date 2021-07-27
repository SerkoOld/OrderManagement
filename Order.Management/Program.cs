using System;
using System.Collections.Generic;
using Order.Management.Colors;
using Order.Management.Reports;
using Order.Management.Shapes;

namespace Order.Management
{
    public class Program
    {
        // Main entry
        public static void Main(string[] args)
        {
            var customer = CustomerInfoInput();

            var orderedShapes = CustomerOrderInput();

            var order = new Order(GetNextOrderNumber(), customer, orderedShapes);

            InvoiceReport(order);

            CuttingListReport(order);

            PaintingReport(order);
        }

        private static string GetNextOrderNumber()
        {
            return "Odr000027";
        }

        private static IEnumerable<Shape> OrderInput<T>(string shapeName) where T : Shape
        {
            var colors = new List<BaseColor>() { new Red(), new Blue(), new Yellow() };
            var shapes = new List<Shape>();

            Console.Write("\n");
            foreach (var color in colors)
            {
                Console.Write($"Please input the number of {color.Name} {shapeName}s: ");
                var colorShapeQuantity = Convert.ToInt32(UserInput());
                var colorShape = ShapeFactory.Create<T>(color, colorShapeQuantity);
                shapes.Add(colorShape);
            }

            return shapes;
        }

        // User Console Input
        private static string UserInput()
        {
            string input = Console.ReadLine();
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
            PaintingReport paintingReport = new PaintingReport(order);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void CuttingListReport(Order order)
        {
            CuttingListReport cuttingListReport = new CuttingListReport(order);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void InvoiceReport(Order order)
        {
            InvoiceReport invoiceReport = new InvoiceReport(order);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static Customer CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = UserInput();
            Console.Write("Please input your Address: ");
            string address = UserInput();
            Console.Write("Please input your Due Date: ");
            string dueDate = UserInput();
            return new Customer(customerName, address, dueDate);
        }

        // Get order input
        private static List<Shape> CustomerOrderInput()
        {
            var square = OrderInput<Square>(nameof(Square));
            var triangle = OrderInput<Triangle>(nameof(Triangle));
            var circle = OrderInput<Circle>(nameof(Circle));

            var orderedShapes = new List<Shape>();
            orderedShapes.AddRange(square);
            orderedShapes.AddRange(triangle);
            orderedShapes.AddRange(circle);

            return orderedShapes;
        }
    }
}
