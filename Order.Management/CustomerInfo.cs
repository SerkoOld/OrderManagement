using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CustomerInfo
    {
        public string Name;
        public string Address;
        public string DueDate;
        public List<Shape> OrderedShape;

        // Get customer Info
        public void CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            Name = UserInput();
            Console.Write("Please input your Address: ");
            Address = UserInput();
            Console.Write("Please input your Due Date: ");
            DueDate = UserInput();
            
        }
        public void CustomerOrderInput()
        {
            var square = (Square)OrderShapeInput(new SquareCreator(),typeof(Square).ToString());
            var triangle = (Triangle)OrderShapeInput(new TriangleCreator(), typeof(Triangle).ToString());
            var circle = (Circle)OrderShapeInput(new CircleCreator(), typeof(Circle).ToString());

            var orderedShapes = new List<Shape>();
            orderedShapes.Add(square);
            orderedShapes.Add(triangle);
            orderedShapes.Add(circle);
            OrderedShape = orderedShapes;
        }

        private Shape OrderShapeInput(ShapeFactory creator, string shapeName)
        {
            Console.Write($"\nPlease input the number of Red {shapeName}: ");
            int redNumber = Convert.ToInt32(UserInput());
            Console.Write($"Please input the number of Blue {shapeName}: ");
            int blueNumber = Convert.ToInt32(UserInput());
            Console.Write($"Please input the number of Yellow {shapeName}: ");
            int yellowNumber = Convert.ToInt32(UserInput());
            return creator.CreateShape(redNumber,blueNumber,yellowNumber);
        }
       
        private string UserInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();
            }
            return input;
        }


    }
}
