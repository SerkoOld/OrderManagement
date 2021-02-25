namespace Order.Management
{
    public abstract class Shape
    {
        public const int RedSurcharge = 1;

        public string Name { get; set; }
        public int Price { get; set; }
        public int NumberOfRedShape { get; set; }
        public int NumberOfBlueShape { get; set; }
        public int NumberOfYellowShape { get; set; }

        public Shape() {}

        public Shape(int redAmount, int blueAmount, int yellowAmount)
        {
            NumberOfRedShape = redAmount;
            NumberOfBlueShape = blueAmount;
            NumberOfYellowShape = yellowAmount;
        }
        
        public int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        public int TotalPrice()
        {
            return (NumberOfRedShape * Price) + (NumberOfBlueShape * Price) + (NumberOfYellowShape * Price);
        }

    }
}
