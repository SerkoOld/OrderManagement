using System;
using System.Collections.Generic;
using System.Linq;
using Order.Management.Models;

namespace Order.Management.Services
{
    /// <summary>
    /// This class is responsible for prompting the user for order information
    /// and creating the OrderInfo object
    /// this is the main UI for the app
    /// </summary>
    public static class Prompt
    {
        /// <summary>
        /// this method takes user input and creates an OrderInfo object
        /// </summary>
        /// <returns>order info, or null if user choose to cancel</returns>
        public static OrderInfo? Run()
        {
            var quit = false;

            Console.WriteLine("name: ");
            var name = Console.ReadLine();
            Console.WriteLine("address: ");
            var address = Console.ReadLine();

            var order = new OrderInfo(name: name, address: address);

            do
            {
                Console.WriteLine(
                    "[q|esc] quit | [a] add toy | [r] remove toy | [p] print order | [enter] finish order");
                var command = Console.ReadKey(true);
                switch (command.Key)
                {
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.Enter:
                        quit = true;
                        break;
                    case ConsoleKey.A:
                        var toys = AddToy();
                        order.Items.AddRange(toys);
                        break;
                    case ConsoleKey.P:
                        Console.WriteLine(
                            $"order# {order.OrderNumber}, due {order.DueDate} name: {order.Name}, address: {order.Address}");
                        foreach (var item in order.Items)
                        {
                            Console.WriteLine($" - {item.Color} {item.Shape}");
                        }

                        break;
                }
            } while (!quit);

            return order;
        }

        private static IEnumerable<Toy> AddToy()
        {
            var shapes = CommonUtils.GetAllShapes();
            var colors = CommonUtils.GetAllColors();
            Console.WriteLine(
                $"Please select shape: {string.Join("|", shapes.Select((s, i) => $"[{i + 1}] {s}"))}");
            var shapeIndex = ReadNumber(n => n > 0 && n <= shapes.Length) - 1;
            Console.WriteLine(
                $"Please select color: {string.Join("|", colors.Select((c, i) => $"[{i + 1}] {c}"))}");
            var colorIndex = ReadNumber(n => n > 0 && n <= shapes.Length) - 1;
            Console.WriteLine($"How many do you want? [default: 1]");
            var quantity = ReadNumber(predicate: n => n > 0, defaultValue: 1);
            return Enumerable.Range(0, quantity).Select(_ => new Toy()
            {
                Color = colors[colorIndex],
                Shape = shapes[shapeIndex],
            });
        }

        /// <summary>
        /// Read a number from console.
        /// if predicate is not null, the number must satisfy the predicate
        /// if user input is empty, return defaultValue
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static int ReadNumber(Predicate<int> predicate = null, int defaultValue = 1)
        {
            var number = defaultValue;
            var stop = false;
            do
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    return number;
                }

                if (int.TryParse(line, out number))
                {
                    if (predicate == null || predicate(number))
                    {
                        stop = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            } while (!stop);

            return number;
        }
    }
}
