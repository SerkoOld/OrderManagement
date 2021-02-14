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

            var orderedShapes = CustomerOrderInput();

            InvoiceReport(customerInfo, orderedShapes);

            CuttingListReport(customerInfo, orderedShapes);

            PaintingReport(customerInfo, orderedShapes);
        }
        
        // Order Circle Input
        public static Circle OrderCirclesInput()
        {
            Console.Write("\nPlease input the number of Red Circle: ");
            int redCircle = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Blue Circle: ");
            int blueCircle = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Yellow Circle: ");
            int yellowCircle = Convert.ToInt32(UserInput());

            Circle circle = new Circle(redCircle, blueCircle, yellowCircle);
            return circle;
        }
        
        // Order Squares Input
        public static Square OrderSquaresInput()
        {
            Console.Write("\nPlease input the number of Red Squares: ");
            int redSquare = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Blue Squares: ");
            int blueSquare = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Yellow Squares: ");
            int yellowSquare = Convert.ToInt32(UserInput());

            Square square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        // Order Triangles Input
        public static Triangle OrderTrianglesInput()
        {
            Console.Write("\nPlease input the number of Red Triangles: ");
            int redTriangle = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Blue Triangles: ");
            int blueTriangle = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Yellow Triangles: ");
            int yellowTriangle = Convert.ToInt32(UserInput());

            Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);
            return triangle;
        }

        // User Console Input
        public static string UserInput()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return UserInput();
            }
            return input;
        }

        // Generate Painting Report 
        private static void PaintingReport(CustomerInfo customerInfo, List<Shape> orderedShapes)
        {
            PaintingReport paintingReport = new PaintingReport(customerInfo, orderedShapes);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void CuttingListReport(CustomerInfo customerInfo, List<Shape> orderedShapes)
        {
            CuttingListReport cuttingListReport = new CuttingListReport(customerInfo, orderedShapes);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void InvoiceReport(CustomerInfo customerInfo, List<Shape> orderedShapes)
        {
            InvoiceReport invoiceReport = new InvoiceReport(customerInfo, orderedShapes);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static CustomerInfo CustomerInfoInput()
        {
            var customerOrderDetails = new CustomerInfo();
            Console.Write("Please input your Name: ");
            customerOrderDetails.CustomerName = UserInput();
            Console.Write("Please input your Address: ");
            customerOrderDetails.Address = UserInput();
            Console.Write("Please input your Due Date: ");
            customerOrderDetails.DueDate = UserInput();
            return customerOrderDetails;
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
