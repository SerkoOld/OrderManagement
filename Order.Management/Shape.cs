using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Shape
    {
        #region Public Properties

        public int TotalPrice { get; private set; }
        public int TotalQuantity { get; private set; }
        public int NumberOfRedShape { get; private set; }
        public int NumberOfBlueShape { get; private set; }
        public int NumberOfYellowShape { get; private set; }

        #endregion

        protected Shape(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape)
        {
            NumberOfRedShape = numberOfRedShape;
            NumberOfBlueShape = numberOfBlueShape;
            NumberOfYellowShape = numberOfYellowShape;
            TotalPrice = Total();
            TotalQuantity = TotalQuantityOfShape();
        }

        #region Abstract properties

        protected abstract string Name { get; }
        protected abstract int Price { get; }
        protected virtual int AdditionalCharge { get => 1; }

        #endregion

        #region Protected Methods

        protected int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        #endregion

        #region Abstract protected methods

        protected virtual int AdditionalChargeTotal()
        {
            return NumberOfRedShape * AdditionalCharge;
        }

        protected virtual int Total()
        {
            return (NumberOfRedShape * Price) + 
                (NumberOfBlueShape * Price) + 
                (NumberOfYellowShape * Price);
        }
        #endregion
    }
}