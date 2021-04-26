using System;
using System.Collections.Generic;

namespace Order.Management
{
    class Program
    {
        // Main entry
        static void Main(string[] args)
        {
            var (customerName, address, dueDate) = CustomerInfoInput();

            var orderedShapes = CustomerOrderInput();

            InvoiceReport(customerName, address, dueDate, orderedShapes);

            CuttingListReport(customerName, address, dueDate, orderedShapes);

            PaintingReport(customerName, address, dueDate, orderedShapes);
        }
        
        // Order Circle Input
        public static Circle OrderCirclesInput()
        {
            Console.Write("\nPlease input the number of Red Circle: ");
            int redCircle = GetUserInputAsInteger();
            Console.Write("Please input the number of Blue Circle: ");
            int blueCircle = GetUserInputAsInteger();
            Console.Write("Please input the number of Yellow Circle: ");
            int yellowCircle = GetUserInputAsInteger();

            Circle circle = new Circle(redCircle, blueCircle, yellowCircle);
            return circle;
        }

        // Order Squares Input
        public static Square OrderSquaresInput()
        {
            Console.Write("\nPlease input the number of Red Squares: ");
            int redSquare = GetUserInputAsInteger();
            Console.Write("Please input the number of Blue Squares: ");
            int blueSquare = GetUserInputAsInteger();
            Console.Write("Please input the number of Yellow Squares: ");
            int yellowSquare = GetUserInputAsInteger();

            Square square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        // Order Triangles Input
        public static Triangle OrderTrianglesInput()
        {
            Console.Write("\nPlease input the number of Red Triangles: ");
            int redTriangle = GetUserInputAsInteger();
            Console.Write("Please input the number of Blue Triangles: ");
            int blueTriangle = GetUserInputAsInteger();
            Console.Write("Please input the number of Yellow Triangles: ");
            int yellowTriangle = GetUserInputAsInteger();

            Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);
            return triangle;
        }

        /// <summary>
        /// Validates user input. If nothing is provided, gives an error and asks user to enter a value again.
        /// </summary>
        /// <returns></returns>
        public static string GetUserInputAsString()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();

            }
            return input;
        }

        /// <summary>
        /// Converts user input to integer. If nothing is provided, cosiders value as zero (as per example in the requirements). If user input cannot be converted into integer, gives an error and asks user to enter value again.
        /// </summary>
        /// <returns></returns>
        public static int GetUserInputAsInteger()
        {
            string input = Console.ReadLine();
            int result;

            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("please enter valid number");
                input = Console.ReadLine();
            }

            return result;
        }

        /// <summary>
        /// Converts user input to date. If user input cannot be converted into date, gives an error and asks user to enter value again.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetUserInputAsDate()
        {
            string input = Console.ReadLine();
            DateTime result;

            while (!DateTime.TryParse(input, out result))
            {
                Console.WriteLine("please enter valid date");
                input = Console.ReadLine();
            }

            return result;
        }

        // Generate Painting Report 
        private static void PaintingReport(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            PaintingReport paintingReport = new PaintingReport(customerName, address, dueDate, orderedShapes);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void CuttingListReport(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            CuttingListReport cuttingListReport = new CuttingListReport(customerName, address, dueDate, orderedShapes);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void InvoiceReport(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            InvoiceReport invoiceReport = new InvoiceReport(customerName, address, dueDate, orderedShapes);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static (string customerName, string address, string dueDate) CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = GetUserInputAsString();
            Console.Write("Please input your Address: ");
            string address = GetUserInputAsString();
            Console.Write("Please input your Due Date: ");
            DateTime dueDate = GetUserInputAsDate();
            return (customerName, address, dueDate.ToString("dd MMM yyyy"));
        }

        // Get order input
        private static List<Shape> CustomerOrderInput()
        {
            Square square = OrderSquaresInput();
            Triangle triangle = OrderTrianglesInput();
            Circle circle = OrderCirclesInput();

            var orderedShapes = new List<Shape>();
            orderedShapes.Add(square);
            orderedShapes.Add(triangle);
            orderedShapes.Add(circle);
            return orderedShapes;
        }
    }
}
