using Order.Management.Model;
using System;
using System.Collections.Generic;

namespace Order.Management
{
    class Program
    {
        // Main entry
        static void Main(string[] args)
        {
            try
            {
                var (customerName, address, dueDate) = CustomerInfoInput();

                var orderedShapes = CustomerOrderInput();

                InvoiceReport(customerName, address, dueDate, orderedShapes);

                CuttingListReport(customerName, address, dueDate, orderedShapes);

                PaintingReport(customerName, address, dueDate, orderedShapes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Order.Management: Error, {ex.Message}");
            }
        }

        // Order Circle Input
        public static Circle OrderCirclesInput()
        {
            int redCircle = GetShapesInput("\nPlease input the number of Red Circle: ");
            Console.Write("Please input the number of Blue Circle: ");
            int blueCircle = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Yellow Circle: ");
            int yellowCircle = Convert.ToInt32(userInput());

            Circle circle = new Circle(redCircle, blueCircle, yellowCircle);
            //circle.Price = 10; 
            //circle.Name = "Square";
            return circle;
        }

        // Order Squares Input
        public static Square OrderSquaresInput()
        {
            int redSquare = GetShapesInput("\nPlease input the number of Red Squares: ");

            Console.Write("Please input the number of Blue Squares: ");
            int blueSquare = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Yellow Squares: ");
            int yellowSquare = Convert.ToInt32(userInput());
            return new Square(redSquare, blueSquare, yellowSquare);
        }

        // Order Triangles Input
        public static Triangle OrderTrianglesInput()
        {
            Console.Write("\nPlease input the number of Red Triangles: ");
            int redTriangle = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Blue Triangles: ");
            int blueTriangle = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Yellow Triangles: ");
            int yellowTriangle = Convert.ToInt32(userInput());

            Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);
            return triangle;
        }

        // User Console Input
        public static string userInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();

            }
            return input;
        }

        public static int GetShapesInput(string label)
        {
            Console.Write(label);
            while (true)
            {
                try
                {
                    return (int)Convert.ToUInt32(userInput());
                }
                catch
                {
                    Console.WriteLine($"Order.Management.ShapesInput, Input error, please enter a valid number");
                }
            }
        }

        // Generate Painting Report 
        private static void PaintingReport(string customerName, string address, DateTime dueDate, List<Shape> orderedShapes)
        {
            PaintingReport paintingReport = new PaintingReport(customerName, address, dueDate, orderedShapes);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void CuttingListReport(string customerName, string address, DateTime dueDate, List<Shape> orderedShapes)
        {
            CuttingListReport cuttingListReport = new CuttingListReport(customerName, address, dueDate, orderedShapes);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void InvoiceReport(string customerName, string address, DateTime dueDate, List<Shape> orderedShapes)
        {
            InvoiceReport invoiceReport = new InvoiceReport(customerName, address, dueDate, orderedShapes);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static (string customerName, string address, DateTime dueDate) CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = userInput();
            Console.Write("Please input your Address: ");
            string address = userInput();
            Console.Write("Please input your Due Date: ");
            string dueDate = userInput();

            if (!DateTime.TryParse(dueDate, out DateTime dateValue))
                Console.WriteLine("  Unable to parse '{0}'.", dateValue);

            return (customerName, address, dateValue);
        }

        // Get order input
        private static List<Shape> CustomerOrderInput()
        {
            try
            {
                var orderedShapes = new List<Shape> { OrderSquaresInput(), OrderTrianglesInput(), OrderCirclesInput() };
                return orderedShapes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Order.Management.CustomerOrderInput, Input error  {ex}");
                throw;
            }
        }
    }
}
