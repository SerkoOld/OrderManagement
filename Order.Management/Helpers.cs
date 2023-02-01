using System;
using System.Collections.Generic;
using System.Drawing;

namespace Order.Management
{
    public static class Helpers
    {
        /// <summary>
        /// Default Method to take in user input
        /// </summary>
        /// <returns></returns>
        public static string userInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();

            }
            return input;
        }

        /// <summary>
        /// Method for taking in no of shapes to be ordered by customer.
        /// </summary>
        /// <returns></returns>
        public static int userShapeNumbers() => Convert.ToInt32(userInput());

        /// <summary>
        /// Prints line after each row entry in a report.
        /// </summary>
        /// <param name="tableWidth"></param>
        public static void PrintLine(int tableWidth)
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        /// <summary>
        /// Checks if entered date is valid format
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsValidDate(DateTime date)
        {
            if (date != null && date > DateTime.Now) return true;
            return false;
        }

        /// <summary>
        /// Prints row with | seperator
        /// </summary>
        /// <param name="tableWidth"></param>
        /// <param name="columns"></param>
        public static void PrintRow(int tableWidth,params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        /// <summary>
        /// Aligns row value in centre based on supplied width.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        /// <summary>
        /// Gets all Subclasses associated with the base class
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllSubclassOf(Type parent)
        {
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                foreach (var t in a.GetTypes())
                    if (t.IsSubclassOf(parent)) yield return t;
        }
    }
}
