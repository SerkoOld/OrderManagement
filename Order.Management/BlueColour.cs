using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class BlueColour : Colour
    {
        public override string ColourName => "Blue";
        public BlueColour(int totalNumber) : base(totalNumber)
        {

        }
    }
}
