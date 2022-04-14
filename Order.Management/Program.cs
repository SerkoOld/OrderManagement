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

            PaintingReport(customerName, address, dueDate,orderedShapes);
        }

        // Order Circle Input
        // OrderCirclesInput()、OrderSquaresInput()、OrderTrianglesInput()
        // The above three methods can be merged as one method by passing parameters(e.g.OrderShapeInput(shape)).
        //public static Circle OrderCirclesInput()
        //{
        //    Console.Write("\nPlease input the number of Red Circle: ");
        //    int redCircle = Convert.ToInt32(userInput());
        //    Console.Write("Please input the number of Blue Circle: ");
        //    int blueCircle = Convert.ToInt32(userInput());
        //    Console.Write("Please input the number of Yellow Circle: ");
        //    int yellowCircle = Convert.ToInt32(userInput());

        //    Circle circle = new Circle(redCircle, blueCircle, yellowCircle);
        //    return circle;
        //}
        
        //// Order Squares Input
        //public static Square OrderSquaresInput()
        //{
        //    Console.Write("\nPlease input the number of Red Squares: ");
        //    int redSquare = Convert.ToInt32(userInput());
        //    Console.Write("Please input the number of Blue Squares: ");
        //    int blueSquare = Convert.ToInt32(userInput());
        //    Console.Write("Please input the number of Yellow Squares: ");
        //    int yellowSquare = Convert.ToInt32(userInput());

        //    Square square = new Square(redSquare, blueSquare, yellowSquare);
        //    return square;
        //}

        //// Order Triangles Input
        //// Use private or protected to replace public,unless special reasons.
        //public static Triangle OrderTrianglesInput()
        //{
        //    Console.Write("\nPlease input the number of Red Triangles: ");
        //    // User input validity check(e.g.Regex reg = new Regex("^[0-9]+$"))
        //    int redTriangle = Convert.ToInt32(userInput());
        //    Console.Write("Please input the number of Blue Triangles: ");
        //    int blueTriangle = Convert.ToInt32(userInput());
        //    Console.Write("Please input the number of Yellow Triangles: ");
        //    int yellowTriangle = Convert.ToInt32(userInput());

        //    Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);
        //    return triangle;
        //}

        private static Order OrderShapeInput(string shape)
        {
            Console.Write("\nPlease input the number of Red " + shape + ": ");
            int red = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Blue " + shape + ": ");
            int blue = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Yellow  " + shape + ": ");
            int yellow = Convert.ToInt32(userInput());

            Order order = new Order();
            order.NumberOfColorShape = new Dictionary<string, int>();
            order.NumberOfColorShape["Red"] = red;
            order.NumberOfColorShape["Blue"] = blue;
            order.NumberOfColorShape["Yellow"] = yellow;
            return order;
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

        // Generate Painting Report 
        private static void PaintingReport(string customerName, string address, string dueDate, List<Order> orderedShapes)
        {
            PaintingReport paintingReport = new PaintingReport(customerName, address, dueDate,orderedShapes);
            paintingReport.GenerateReport();
        }

        // Generate Painting Report 
        private static void CuttingListReport(string customerName, string address, string dueDate, List<Order> orderedShapes)
        {
            CuttingListReport cuttingListReport = new CuttingListReport(customerName, address, dueDate,orderedShapes);
            cuttingListReport.GenerateReport();
        }

        // Generate Invoice Report 
        private static void InvoiceReport(string customerName, string address, string dueDate, List<Order> orderedShapes)
        {
            InvoiceReport invoiceReport = new InvoiceReport(customerName, address, dueDate,orderedShapes);
            invoiceReport.GenerateReport();
        }

        // Get customer Info
        private static (string customerName, string address, string dueDate) CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = userInput();
            Console.Write("Please input your Address: ");
            string address = userInput();
            Console.Write("Please input your Due Date: ");
            //Convert user input to DateTime type.
            string dueDate = userInput();
            return (customerName, address, dueDate);
        }

        // Get order input
        private static List<Order> CustomerOrderInput()
        {
            Order SquareOrder = OrderShapeInput("Square");
            Order TriangleOrder = OrderShapeInput("Triangle");
            Order CircleOrder = OrderShapeInput("Circle");

            var orderedShapes = new List<Order>();
            orderedShapes.Add(SquareOrder);
            orderedShapes.Add(TriangleOrder);
            orderedShapes.Add(CircleOrder);
            return orderedShapes;
        }

        // Get order input
        //private static List<Shape> CustomerOrderInput()
        //{
        //    Square square = OrderSquaresInput();
        //    Triangle triangle = OrderTrianglesInput();
        //    Circle circle = OrderCirclesInput();

        //    var orderedShapes = new List<Shape>();
        //    orderedShapes.Add(square);
        //    orderedShapes.Add(triangle);
        //    orderedShapes.Add(circle);
        //    return orderedShapes;
        //}
    }
}
