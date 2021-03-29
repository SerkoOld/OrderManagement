namespace Order.Management
{
    abstract class Shape
    {
        private int _additionalCharge = 1;
        protected string Name { get; set; }  
        public int Price { get; protected set; }
        public int AdditionalCharge { get; }
        public int NumberOfRedShape { get; }
        public int NumberOfBlueShape { get; }
        public int NumberOfYellowShape { get; }

        protected Shape(int red, int blue, int yellow) 
        {
            NumberOfRedShape = red;
            NumberOfBlueShape = blue;
            NumberOfYellowShape = yellow;
            AdditionalCharge = _additionalCharge;
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

