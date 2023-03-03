using System;
using NUnit.Framework;
using Order.Management.Models;

namespace Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void TestMatrix()
        {
            var rows = new[] {"a", "b", "c"};
            var columns = new[] {1, 2, 3};
            var m = new Matrix<string, int, int>(rows, columns)
            {
                ["a", 2] = 4,
            };
            Assert.AreEqual(rows, m.Rows);
            Assert.AreEqual(columns, m.Columns);
            Assert.AreEqual(m["a", 2], 4);
            Assert.AreEqual(m["a", 1], 0); // default value for int is 0
        }

        public void TestMatrixWithWrongIndex()
        {
            var m = new Matrix<string, string, int>(rows: new[] {"a"}, columns: new[] {"b"})
            {
                ["a", "b"] = 4,
            };
            Assert.Throws<IndexOutOfRangeException>(() => m["a", "4"] = 5);
        }
    }
}
