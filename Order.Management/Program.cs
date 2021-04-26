using Order.Management.OrderDetails;
using Order.Management.Reports;
using Order.Management.Shapes;
using System;
using System.Collections.Generic;

namespace Order.Management
{
    class Program
    {
        // Main entry
        static void Main(string[] args)
        {
            var customerInfo = CustomerInfoInput();
            var customerDueDate = CustomerDueDateInput();
            var orderedShapes = CustomerOrderInput();

            var order = new OrderDetails.Order(customerInfo, customerDueDate, orderedShapes);

            InvoiceReport(order);
            CuttingListReport(order);
            PaintingReport(order);
        }
        
        // Order Circle Input
        public static Circle OrderCirclesInput()
        {
            Console.Write("\nPlease input the number of Red Circle: ");
            int redCircle = GetUserInputAsPositiveInteger();
            Console.Write("Please input the number of Blue Circle: ");
            int blueCircle = GetUserInputAsPositiveInteger();
            Console.Write("Please input the number of Yellow Circle: ");
            int yellowCircle = GetUserInputAsPositiveInteger();

            Circle circle = new Circle(redCircle, blueCircle, yellowCircle);
            return circle;
        }

        // Order Squares Input
        public static Square OrderSquaresInput()
        {
            Console.Write("\nPlease input the number of Red Squares: ");
            int redSquare = GetUserInputAsPositiveInteger();
            Console.Write("Please input the number of Blue Squares: ");
            int blueSquare = GetUserInputAsPositiveInteger();
            Console.Write("Please input the number of Yellow Squares: ");
            int yellowSquare = GetUserInputAsPositiveInteger();

            Square square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        // Order Triangles Input
        public static Triangle OrderTrianglesInput()
        {
            Console.Write("\nPlease input the number of Red Triangles: ");
            int redTriangle = GetUserInputAsPositiveInteger();
            Console.Write("Please input the number of Blue Triangles: ");
            int blueTriangle = GetUserInputAsPositiveInteger();
            Console.Write("Please input the number of Yellow Triangles: ");
            int yellowTriangle = GetUserInputAsPositiveInteger();

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
        /// Converts user input to integer. If nothing is provided, cosiders value as zero (as per example in the requirements). 
        /// If user input cannot be converted into integer or is a negative integer, it gives an error and asks user to enter value again.
        /// </summary>
        /// <returns></returns>
        public static int GetUserInputAsPositiveInteger()
        {
            string input = Console.ReadLine();
            int result;

            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            while (!int.TryParse(input, out result) || result < 0)
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
        private static void PaintingReport(OrderDetails.Order order)
        {
            PaintingReport paintingReport = new PaintingReport(order);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void CuttingListReport(OrderDetails.Order order)
        {
            CuttingListReport cuttingListReport = new CuttingListReport(order);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void InvoiceReport(OrderDetails.Order order)
        {
            InvoiceReport invoiceReport = new InvoiceReport(order);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static CustomerInfo CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = GetUserInputAsString();
            Console.Write("Please input your Address: ");
            string address = GetUserInputAsString();

            var customerInfo = new CustomerInfo(customerName, address);

            return customerInfo;
        }

        // Get due date
        private static DateTime CustomerDueDateInput()
        {
            Console.Write("Please input your Due Date: ");
            DateTime dueDate = GetUserInputAsDate();
            return dueDate;
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
