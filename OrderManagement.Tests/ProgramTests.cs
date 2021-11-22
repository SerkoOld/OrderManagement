using NUnit.Framework;
using System;
using System.IO;
using Order.Management;
using System.Reflection;
using System.Text;

namespace OrderManagement.Tests
{
    public class ProgramTests
    {
        [Test]
        public void ProgramTest()
        {
            var actualOutput = new StringWriter();
            Console.SetOut(actualOutput);

            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug\\netcoreapp3.1", "");
            var input = new StreamReader($"{currentDir}\\TestData\\input.txt");
            Console.SetIn(input);

            Program.Main(new string[] { });

            using var fs = new FileStream($"{currentDir}\\TestData\\output.txt", FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, Encoding.UTF8);
            string expectedOutput = sr.ReadToEnd();
            var temp = actualOutput.ToString();
            Assert.That(actualOutput.ToString(), Is.EqualTo(expectedOutput));
        }
    }
}