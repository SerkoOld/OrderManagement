using Order.Management.Exceptions;

namespace Order.Management.Shapes
{
    public abstract class Shape
    {
        abstract public ShapeName Name { get; }
        abstract public decimal Price { get; }

        public static decimal RedColorSurcharge => 1;
        public int NumberOfRedShape { get; }
        public int NumberOfBlueShape { get; }
        public int NumberOfYellowShape { get; }

        protected Shape(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape)
        {
            NumberOfRedShape = numberOfRedShape < 0 ? throw new ShapeNumberIsNegativeException() : numberOfRedShape;
            NumberOfBlueShape = numberOfBlueShape < 0 ? throw new ShapeNumberIsNegativeException() : numberOfBlueShape;
            NumberOfYellowShape = numberOfYellowShape < 0 ? throw new ShapeNumberIsNegativeException() : numberOfYellowShape;
        }

        public int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        public decimal RedColorChargeTotal()
        {
            return NumberOfRedShape * RedColorSurcharge;
        }

        public decimal Total()
        {
            return RedShapeTotalPrice() + BlueShapeTotalPrice() + YellowShapeTotalPrice();
        }

        private decimal RedShapeTotalPrice()
        {
            return (NumberOfRedShape * Price);
        }
        private decimal BlueShapeTotalPrice()
        {
            return (NumberOfBlueShape * Price);
        }
        private decimal YellowShapeTotalPrice()
        {
            return (NumberOfYellowShape * Price);
        }
    }
}
