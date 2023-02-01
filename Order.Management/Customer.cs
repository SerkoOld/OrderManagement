using System;
using System.Collections.Generic;
using Order.Management.Shapes;

namespace Order.Management
{
    public interface ICustomer
    {
        public string ToString();
        public void OrderShapes();
        public Shape GetShape(string shapeName);
    }
    public class Customer: ICustomer 
    {
        public readonly IEnumerable<Type> Shapes = Helpers.GetAllSubclassOf(typeof(Shape));
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        public int OrderNumber { get => 1000; }
        public Dictionary<string,Shape> OrderedBlocks { get; set; }

        public Customer()
        {
            try
            {
                OrderedBlocks = new Dictionary<string, Shape>();
                CustomerInfoInput();
                OrderShapes();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets required input parameters to place Customer order
        /// </summary>
        public void CustomerInfoInput()
        {
            foreach (var prompt in new List<string> { "Name","Address","Due Date"})
            {
                if (prompt == "Due Date")
                {
                    Console.Write($"Please input your {prompt} [format(DD-MM-YYY)]: ");
                    DueDate = Helpers.userInput();
                    while (!Helpers.IsValidDate(Convert.ToDateTime(DueDate)))
                    {
                        Console.Write($"Invalid date {prompt}, entered date {DueDate} cannot be in the past. Please try again: ");
                        DueDate = Helpers.userInput();
                    }
                }else if (prompt == "Address")
                {
                    Console.Write($"Please input your {prompt}: ");
                    Address = Helpers.userInput();
                }else if(prompt == "Name")
                {
                    Console.Write($"Please input your {prompt}: ");
                    CustomerName = Helpers.userInput();
                }
            }
        }

        /// <summary>
        /// Allows ordering of different shapes and associated colours
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void OrderShapes()
        {
            foreach (var shape in Shapes)
            {
                switch (shape.Name)
                {
                    case nameof(Circle):
                        ColourConfig.Prompt<Circle>(1);
                        OrderedBlocks.Add(shape.Name, new Circle(shape.Name, 3, ColourConfig.ColoursDict));
                        continue;
                    case nameof(Triangle):
                        ColourConfig.Prompt<Triangle>(1);
                        OrderedBlocks.Add(shape.Name, new Triangle(shape.Name, 2,ColourConfig.ColoursDict));
                        continue;
                    case nameof(Square):
                        ColourConfig.Prompt<Square>(1);
                        OrderedBlocks.Add(shape.Name, new Square(shape.Name, 1, ColourConfig.ColoursDict));
                        continue;
                    default: 
                        throw new Exception("Error: Invalid shape");
                }
            }
        }

        /// <summary>
        /// Get Shape object and information associated with it.
        /// </summary>
        /// <param name="shapeName">type of Shape</param>
        /// <returns></returns>
        public Shape GetShape(string shapeName) => OrderedBlocks.TryGetValue(shapeName, out var shape) ? shape : null;

        /// <summary>
        /// Prints Customer information along with Order No and Due date.
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>  "\nName: " + this.CustomerName + " Address: " + this.Address + " Due Date: " + this.DueDate + " Order #: " + this.OrderNumber;

    }
}
