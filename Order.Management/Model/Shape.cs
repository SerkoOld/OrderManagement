namespace Order.Management.Model
{
    abstract class Shape
    {
        public abstract string Name { get; }// Name & Price & AdditionalCharge cannot be allowed to be changed by the consumer
        public abstract int Price { get; }
        public int AdditionalCharge { get; }
        public int NumberOfRedShape { get; set; }
        public int NumberOfBlueShape { get; set; }
        public int NumberOfYellowShape { get; set; }
        public int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }
        public int AdditionalChargeTotal()
        {
            return NumberOfRedShape * AdditionalCharge;
        }
        public abstract int Total();
    }
}
