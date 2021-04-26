namespace Order.Management.Shapes
{
    public abstract class Shape
    {
        abstract public string Name { get; }
        abstract public int Price { get; }

        public int RedColorSurcharge => 1;
        public int NumberOfRedShape { get; }
        public int NumberOfBlueShape { get; }
        public int NumberOfYellowShape { get; }

        protected Shape(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape)
        {
            NumberOfRedShape = numberOfRedShape;
            NumberOfBlueShape = numberOfBlueShape;
            NumberOfYellowShape = numberOfYellowShape;
        }

        public int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        public int RedColorChargeTotal()
        {
            return NumberOfRedShape * RedColorSurcharge;
        }

        public int Total()
        {
            return RedShapeTotalPrice() + BlueShapeTotalPrice() + YellowShapeTotalPrice();
        }

        private int RedShapeTotalPrice()
        {
            return (NumberOfRedShape * Price);
        }
        private int BlueShapeTotalPrice()
        {
            return (NumberOfBlueShape * Price);
        }
        private int YellowShapeTotalPrice()
        {
            return (NumberOfYellowShape * Price);
        }
    }
}
