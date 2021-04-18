using System;
using System.Collections.Generic;

namespace Order.Management
{
    class Program
    {
        // Main entry
        private static void Main()
        {
            var (customerName, address, dueDate) = CustomerInfoInput();

            var orderedShapes = CustomerOrderInput();

            InvoiceReport(customerName, address, dueDate, orderedShapes);

            CuttingListReport(customerName, address, dueDate, orderedShapes);

            PaintingReport(customerName, address, dueDate, orderedShapes);
        }
        
        // Order Circle Input
        private static Circle OrderCirclesInput()
        {
            Console.Write("\nPlease input the number of Red Circle: ");
            var redCircle = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Blue Circle: ");
            var blueCircle = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Yellow Circle: ");
            var yellowCircle = Convert.ToInt32(UserInput());

            var circle = new Circle(redCircle, blueCircle, yellowCircle);
            return circle;
        }
        
        // Order Squares Input
        private static Square OrderSquaresInput()
        {
            Console.Write("\nPlease input the number of Red Squares: ");
            var redSquare = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Blue Squares: ");
            var blueSquare = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Yellow Squares: ");
            var yellowSquare = Convert.ToInt32(UserInput());

            var square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        // Order Triangles Input
        private static Triangle OrderTrianglesInput()
        {
            Console.Write("\nPlease input the number of Red Triangles: ");
            var redTriangle = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Blue Triangles: ");
            var blueTriangle = Convert.ToInt32(UserInput());
            Console.Write("Please input the number of Yellow Triangles: ");
            var yellowTriangle = Convert.ToInt32(UserInput());

            var triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);
            return triangle;
        }

        // User Console Input
        private static string UserInput()
        {
            var input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();

            }
            return input;
        }

        // Generate Painting Report 
        private static void PaintingReport(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            var paintingReport = new PaintingReport(customerName, address, dueDate, orderedShapes);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void CuttingListReport(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            var cuttingListReport = new CuttingListReport(customerName, address, dueDate, orderedShapes);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void InvoiceReport(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            var invoiceReport = new InvoiceReport(customerName, address, dueDate, orderedShapes);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static (string customerName, string address, string dueDate) CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            var customerName = UserInput();
            Console.Write("Please input your Address: ");
            var address = UserInput();
            Console.Write("Please input your Due Date: ");
            var dueDate = UserInput();
            return (customerName, address, dueDate);
        }

        // Get order input
        private static List<Shape> CustomerOrderInput()
        {
            var square = OrderSquaresInput();
            var triangle = OrderTrianglesInput();
            var circle = OrderCirclesInput();

            var orderedShapes = new List<Shape> {square, triangle, circle};
            return orderedShapes;
        }
    }
}
