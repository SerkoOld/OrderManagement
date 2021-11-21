using NUnit.Framework;
using System;
using System.IO;
using Order.Management;
using System.Reflection;
using System.Text;

namespace OrderManagement.Tests
{
    public class Tests
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

            Assert.That(actualOutput.ToString().Replace("\n",Environment.NewLine).Replace("\r\r","\r"), Is.EqualTo(expectedOutput));
        }
    }
}