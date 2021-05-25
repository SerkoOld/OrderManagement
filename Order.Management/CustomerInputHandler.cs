using Order.Management.ToyBlocks;
using System;
using System.Collections.Generic;

namespace Order.Management
{
    public class CustomerInputHandler
    {
        // Get customer Info
        public (string customerName, string address, string dueDate) GetCustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = GetUserInputAsString();

            Console.Write("Please input your Address: ");
            string address = GetUserInputAsString();

            Console.Write("Please input your Due Date: "); // TODO: should probably be DateTime with valid user input for DateTime
            string dueDate = GetUserInputAsString();

            return (customerName, address, dueDate);
        }

        public List<Shape> GetCustomerOrderInput()
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

        private static Circle OrderCirclesInput()
        {
            Console.Write("\nPlease input the number of Red Circle: ");
            int redCircle = GetUserInputAsInt();

            Console.Write("Please input the number of Blue Circle: ");
            int blueCircle = GetUserInputAsInt();

            Console.Write("Please input the number of Yellow Circle: ");
            int yellowCircle = GetUserInputAsInt();

            Circle circle = new Circle(redCircle, blueCircle, yellowCircle);

            return circle;
        }

        private static Square OrderSquaresInput()
        {
            Console.Write("\nPlease input the number of Red Squares: ");
            int redSquare = GetUserInputAsInt();

            Console.Write("Please input the number of Blue Squares: ");
            int blueSquare = GetUserInputAsInt();

            Console.Write("Please input the number of Yellow Squares: ");
            int yellowSquare = GetUserInputAsInt();

            Square square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        private static Triangle OrderTrianglesInput()
        {
            Console.Write("\nPlease input the number of Red Triangles: ");
            int redTriangle = GetUserInputAsInt();

            Console.Write("Please input the number of Blue Triangles: ");
            int blueTriangle = GetUserInputAsInt();

            Console.Write("Please input the number of Yellow Triangles: ");
            int yellowTriangle = GetUserInputAsInt();

            Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);

            return triangle;
        }

        private static string GetUserInputAsString()
        {
            string input = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();
            }

            return input;
        }

        private static int GetUserInputAsInt()
        {
            string input = GetUserInputAsString();

            while (!int.TryParse(input, out var _))
            {
                Console.WriteLine("please enter valid details");
                input = GetUserInputAsString();
            }

            return int.Parse(input);
        }
    }
}
