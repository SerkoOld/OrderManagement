using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    interface IReport
    {
        public void GenerateTable();
        public void GenerateReport();

        public void PrintLine()
        {
        }

        public void PrintRow(params string[] columns)
        {
        }

        public string AlignCentre(string text, int width)
        {
            return null;
        }

    }
}
