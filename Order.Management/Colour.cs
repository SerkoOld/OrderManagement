using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Colour
    {
        public abstract string ColourName { get; }

        public virtual int SurchargeAmount => 0;

        public int TotalNumber { get; private set; }

        public int TotalSurchargeAmount { get; private set; }

        protected Colour(int totalNumber)
        {
            TotalNumber = totalNumber;
            TotalSurchargeAmount = TotalNumber * TotalSurchargeAmount;
        }
    }
}
