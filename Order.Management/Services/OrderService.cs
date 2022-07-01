using System;
using Order.Management.Domain;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Order.Management.Services
{
    public class OrderService
    {
        public OrderInfo GetCustomerInput()
        {
            var customerInfoInput = CustomerInfoInput();

            var toyInfoInput = ToyInfoInput();

            return new OrderInfo()
            {
                OrderNumber = new Random().Next(),
                CustomerInfo = customerInfoInput,
                ToyInfos = toyInfoInput
            };
        }

        // Get customer Info
        private static CustomerInfo CustomerInfoInput()
        {
            var customerInfo = new CustomerInfo();
            Console.Write("Please input your Name: ");
            customerInfo.CustomerName = UserNameStringInput();
            Console.Write("Please input your Address: ");
            customerInfo.Address = UserStringInput();
            Console.Write("Please input your Due Date: ");
            customerInfo.DueDate = UserDateInput();
            return customerInfo;
        }

        // User Name String Input
        private static string UserNameStringInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) && input.Length > 50)
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();
            }
            return input;
        }

        // User Console String Input
        private static string UserStringInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();
            }
            return input;
        }

        // User Console Date Input
        private static DateTime UserDateInput()
        {
            string input = Console.ReadLine();
            DateTime dueDate;
            while (!DateTime.TryParse(input, out dueDate) && dueDate < DateTime.Now)
            {
                Console.WriteLine("please enter a valid Date");
                input = Console.ReadLine();
            }

            while (Convert.ToDateTime(input) < DateTime.Now)
            {
                Console.WriteLine("please enter a valid no less than date time now");
                input = Console.ReadLine();
            }
            return dueDate;
        }

        // Get order input
        private static List<ToyInfo> ToyInfoInput()
        {
            var toylist = new List<ToyInfo>();
            foreach (var shape in Util.Util.ShapeList)
            {
                Console.Write($"\n");
                foreach (var color in Util.Util.ColorList)
                {
                    Console.Write($"Please input the number of {color} {shape}: ");
                    int quantity = ToyCountInput();
                    toylist.Add(new ToyInfo()
                    {
                        Shape = shape,
                        Color = color,
                        Quantity = quantity
                    });
                }
            }
            return toylist;
        }

        // User Console Number Input
        private static int ToyCountInput()
        {

            Regex reg = new Regex(@"^\d+$");
            string input = Console.ReadLine();
            int inputNumber;

            if (string.IsNullOrWhiteSpace(input))
            {
                input = "0";
            }

            while (!Int32.TryParse(input, out inputNumber))
            {
                Console.WriteLine("please enter a valid number");
                input = Console.ReadLine();

            }

            while (!reg.IsMatch(input) || Convert.ToInt32(input) < 0) 
            {
                Console.WriteLine("please enter a valid number");
                input = Console.ReadLine();
            }
            return Convert.ToInt32(input);
        }
    }
}
