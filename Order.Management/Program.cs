using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Order.Management
{
    enum UserStrInputType
    {
        Name,
        Address,
        DueDate
    }

    class Program
    {

        // Main entry
#pragma warning disable IDE0060 // Remove unused parameter
        static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            var (customerName, address, dueDate) = CustomerInfoInput();

            List<Shape> orderedShapes = CustomerOrderInput();

            InvoiceReport(customerName, address, dueDate, orderedShapes);

            CuttingListReport(customerName, address, dueDate, orderedShapes);

            PaintingReport(customerName, address, dueDate, orderedShapes);
        }

        // Order Circle Input
        public static Circle OrderCirclesInput
        {
            get
            {
                Console.Write("\nPlease input the number of Red Circle: ");
                int redCircle = UserNumberInput();

                Console.Write("Please input the number of Blue Circle: ");
                int blueCircle = UserNumberInput();

                Console.Write("Please input the number of Yellow Circle: ");
                int yellowCircle = UserNumberInput();

                Circle circle = new Circle(redCircle, blueCircle, yellowCircle);
                return circle;
            }
        }

        // Order Squares Input
        public static Square OrderSquaresInput()
        {
            Console.Write("\nPlease input the number of Red Squares: ");
            int redSquare = UserNumberInput();

            Console.Write("Please input the number of Blue Squares: ");
            int blueSquare = UserNumberInput();

            Console.Write("Please input the number of Yellow Squares: ");
            int yellowSquare = UserNumberInput();

            Square square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        // Order Triangles Input
        public static Triangle OrderTrianglesInput()
        {
            Console.Write("\nPlease input the number of Red Triangles: ");
            int redTriangle = UserNumberInput();

            Console.Write("Please input the number of Blue Triangles: ");
            int blueTriangle = UserNumberInput();

            Console.Write("Please input the number of Yellow Triangles: ");
            int yellowTriangle = UserNumberInput();

            Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);
            return triangle;
        }

        // User Console Input
        public static string UserInput() 
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();

            }
            return input;
        }

        //Add-on: User Console Number Input
        public static int UserNumberInput()
        {
            string strInput = UserInput();
            while (!Regex.IsMatch(strInput, @"^(?=.{1,9}$)[0-9]+$")) 
            {
              Console.WriteLine("Please only input numbers");
              strInput = UserInput();
            }

            return Convert.ToInt32(strInput); 
        }

        public static string UserStringInput(UserStrInputType inputType)
        {
            string strInput = UserInput();
            switch (inputType)
            {
                case UserStrInputType.Name:
                case UserStrInputType.Address:
                    while (!Regex.IsMatch(strInput, @"^[0-9a-zA-Z]{3,}"))
                    {
                        Console.WriteLine("Requires minimum input of 3 characters");
                        strInput = UserInput();
                    }
                    break;

                case UserStrInputType.DueDate:
                    while (!Regex.IsMatch(strInput, @"^(?=.{2,11}$)(([0-9])|([0-2][0-9])|([3][0-1]))\s(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\s\d{4}"))
                    {
                        Console.WriteLine("Date input needs to be at least 11 characters in DD Mon YYYY format (e.g. 19 Jan 2019)");
                        strInput = UserInput();
                    }
                    break;
            }

            return strInput;
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
            string customerName = UserStringInput(UserStrInputType.Name);
            
            Console.Write("Please input your Address: "); 
            string address = UserStringInput(UserStrInputType.Address);

            Console.Write("Please input your Due Date: ");
            string dueDate = UserStringInput(UserStrInputType.DueDate);

            return (customerName, address, dueDate);
        }

        // Get order input
        private static List<Shape> CustomerOrderInput()
        {
            Square square = OrderSquaresInput();
            Triangle triangle = OrderTrianglesInput();
            Circle circle = OrderCirclesInput;

            var orderedShapes = new List<Shape>
            {
                square,
                triangle,
                circle
            };

            return orderedShapes;
        }
    }
}
