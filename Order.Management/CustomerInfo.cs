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
            var square = (Square)OrderShapeInput(new SquareCreator());
            var triangle = (Triangle)OrderShapeInput(new TriangleCreator());
            var circle = (Circle)OrderShapeInput(new CircleCreator());

            var orderedShapes = new List<Shape>();
            orderedShapes.Add(square);
            orderedShapes.Add(triangle);
            orderedShapes.Add(circle);
            OrderedShape = orderedShapes;
        }

        private Shape OrderShapeInput(ShapeFactory creator)
        {
            Console.Write(Environment.NewLine);
            var colorNumbers = new Dictionary<Color, int>();
            Console.Write($"Please input the number of Red {creator.Name}: ");
            int redNumber = Convert.ToInt32(UserInput());
            colorNumbers.Add(Color.Red, redNumber);
            Console.Write($"Please input the number of Blue {creator.Name}: ");
            int blueNumber = Convert.ToInt32(UserInput());
            colorNumbers.Add(Color.Blue, blueNumber);
            Console.Write($"Please input the number of Yellow {creator.Name}: ");
            int yellowNumber = Convert.ToInt32(UserInput());
            colorNumbers.Add(Color.Yellow, yellowNumber);
            return creator.CreateShape(colorNumbers);
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
