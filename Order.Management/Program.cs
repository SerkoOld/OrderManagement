using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            int redCircle = ReadInt("\nPlease input the number of Red Circle: ");                        
            int blueCircle = ReadInt("Please input the number of Blue Circle: ");
            int yellowCircle = ReadInt("Please input the number of Yellow Circle: ");

            Circle circle = new Circle(redCircle, blueCircle, yellowCircle);
            return circle;
        }
        
        // Order Squares Input
        public static Square OrderSquaresInput()
        {
            int redSquare = ReadInt("\nPlease input the number of Red Squares: ");
            int blueSquare = ReadInt("Please input the number of Blue Squares: ");
            int yellowSquare = ReadInt("Please input the number of Yellow Squares: ");

            Square square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        // Order Triangles Input
        public static Triangle OrderTrianglesInput()
        {
            int redTriangle = ReadInt("\nPlease input the number of Red Triangles: ");
            int blueTriangle = ReadInt("Please input the number of Blue Triangles: ");
            int yellowTriangle = ReadInt("Please input the number of Yellow Triangles: ");

            Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);
            return triangle;
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
            string customerName = ReadName("Please input your Name: ");
            string address = ReadAddress("Please input your Address: ");
            string dueDate = ReadDate("Please input your Due Date: ").ToString();
            return (customerName, address, dueDate);
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

        // Create a funcion to read int only 
        private static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            string number = Console.ReadLine(); 
            int value;
            while(!Int32.TryParse(number, out value))
            {
                Console.Write("Not a valid number, try again: ");
                number = Console.ReadLine();
            }
            return value; 
        }
        // Create a function to read names only {first name + last name} 
        private static string ReadName(string prompt)
        {
            Console.Write(prompt);
            string name = Console.ReadLine();
            while (!Regex.IsMatch(name, @"^[A-Za-zÀ-ú]+ [A-Za-zÀ-ú]+$")) 
            {
                Console.Write("Name must be 1-35 alfanum, try again: ");
                name = Console.ReadLine();
            }
            return name;
        }
        // Create a fuction to read string only. This can be improved depending on the address format 
        public static string ReadAddress(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.Write("Please enter a valid address: ");
                input = Console.ReadLine();
            }
            return input;
        }
        // Create a function that returns a DateTime type only
        private static DateTime ReadDate(string prompt)
        {
            Console.Write(prompt);
            string date = Console.ReadLine();
            DateTime value;
            while (!DateTime.TryParse(date, out value))
            {
                Console.Write("Not a valid date, try again: ");
                date = Console.ReadLine();
            }
            return value;
        }
    }
}
