using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    //interface would be better (composition over inheritance)
    abstract class Shape
    {
        //instance vars are too public and have no immutability
        public string Name { get; set; }
        public int Price { get; set; }
        public int AdditionalCharge { get; set; }  //should probably hide implementation detail
        public int NumberOfRedShape { get; set; }// I would suggest using decorater pattern something like  IShape shape = new RedShape(new SquareShape(new Shape(3)));
        public int NumberOfBlueShape { get; set; }
        public int NumberOfYellowShape { get; set; }
        public int TotalQuantityOfShape() // would consider making shape smart enough to print itself in report rather than client of shape asking for quantity and then have client responsibile for printing it
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        public int AdditionalChargeTotal()// additional charge should probably be encapsulated away and only visible behaviour is price value
        {
            return NumberOfRedShape * AdditionalCharge;
        }
        public abstract int Total();

    }
}
