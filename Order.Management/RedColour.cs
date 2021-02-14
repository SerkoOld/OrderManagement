using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class RedColour : Colour
    {
        public override string ColourName => "Red";

        public RedColour(int totalNumber) : base(totalNumber)
        {
        }
    }
}
