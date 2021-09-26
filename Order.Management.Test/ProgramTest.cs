using System;
using System.IO;
using System.Reflection;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using Xunit;

namespace Order.Management.Test
{
    [UseReporter(typeof(DiffReporter))]
    [UseApprovalSubdirectory("Approvals")]
    public class ProgramTest
    {
        [Fact]
        public void TestMainOutputs()
        {
            using var fakeStdout = new StringWriter();
            Console.SetOut(fakeStdout);

            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using var inputNames = new StreamReader($@"{currentDir}/Approvals/input.txt");
            // Tell console to get its input from the file, not from the keyboard
            Console.SetIn(inputNames);

            Program.Main(new string[] { });
            Approvals.Verify(fakeStdout.ToString());
        }
    }
}