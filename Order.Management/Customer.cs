using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Order.Management
{
    public interface IShapeFactory
    {
        void OrderShapes();
        Shape GetShape(string shapeName);
    }
    public class Customer: IShapeFactory 
    {
        public readonly List<Type> Shapes = new List<Type>() { typeof(Circle), typeof(Triangle), typeof(Square) };
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        public int OrderNumber { get; set; }
        public Dictionary<string,Shape> OrderedBlocks { get; set; }

        public Customer()
        {
            OrderedBlocks = new Dictionary<string,Shape>();
            CustomerInfoInput();
            OrderShapes();
        }

        // Get customer Info
        public void CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            CustomerName = Helpers.userInput();
            Console.Write("Please input your Address: ");
            Address = Helpers.userInput();
            Console.Write("Please input your Due Date: ");
            DueDate = Helpers.userInput();
        }

        public void OrderShapes()
        {
            foreach (var shape in Shapes)
            {
                
                switch (shape.Name)
                {
                    case nameof(Circle):
                        ColourConfig.Prompt<Circle>();
                        OrderedBlocks.Add(shape.Name, new Circle(shape.Name, 3, 1, ColourConfig.ColourCounts));
                        continue;
                    case nameof(Triangle):
                        ColourConfig.Prompt<Triangle>();
                        OrderedBlocks.Add(shape.Name, new Triangle(shape.Name, 2, 1, ColourConfig.ColourCounts));
                        continue;
                    case nameof(Square):
                        ColourConfig.Prompt<Square>();
                        OrderedBlocks.Add(shape.Name, new Square(shape.Name, 1, 1, ColourConfig.ColourCounts));
                        continue;
                    default: 
                        continue;
                }
            }
        }

        public Shape GetShape(string shapeName) => OrderedBlocks.TryGetValue(shapeName, out var shape) ? shape : null;
    }
}
