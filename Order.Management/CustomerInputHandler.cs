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
            string customerName = GetUserInputAsString("Please input your Name: ");

            string address = GetUserInputAsString("Please input your Address: ");

            // TODO: should probably be DateTime with valid user input for DateTime
            string dueDate = GetUserInputAsString("Please input your Due Date: ");

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
            Console.WriteLine();
            int redCircle = GetUserInputAsInt("Please input the number of Red Circle: ");
            int blueCircle = GetUserInputAsInt("Please input the number of Blue Circle: ");
            int yellowCircle = GetUserInputAsInt("Please input the number of Yellow Circle: ");

            Circle circle = new Circle(redCircle, blueCircle, yellowCircle);

            return circle;
        }

        private static Square OrderSquaresInput()
        {
            Console.WriteLine();
            int redSquare = GetUserInputAsInt("Please input the number of Red Squares: ");
            int blueSquare = GetUserInputAsInt("Please input the number of Blue Squares: ");
            int yellowSquare = GetUserInputAsInt("Please input the number of Yellow Squares: ");

            Square square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        private static Triangle OrderTrianglesInput()
        {
            Console.WriteLine();
            int redTriangle = GetUserInputAsInt("Please input the number of Red Triangles: ");
            int blueTriangle = GetUserInputAsInt("Please input the number of Blue Triangles: ");
            int yellowTriangle = GetUserInputAsInt("Please input the number of Yellow Triangles: ");

            Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);

            return triangle;
        }

        private static string GetUserInputAsString(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            Console.Write(message);

            // Get user input
            string input = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                Console.Write(message);
                input = Console.ReadLine();
            }

            return input;
        }

        private static int GetUserInputAsInt(string message) //TODO: example had ints being nullable from input
        {
            string input = GetUserInputAsString(message);

            while (!int.TryParse(input, out var _))
            {
                Console.WriteLine("please enter valid details");
                input = GetUserInputAsString(message);
            }

            return int.Parse(input);
        }
    }
}
