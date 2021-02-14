using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class YellowColour : Colour
    {
        public override string ColourName => "Yellow";

        public YellowColour(int totalNumber) : base(totalNumber)
        {

        }
    }
}
