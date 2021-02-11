namespace Order.Management
{
    abstract class Shape
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int AdditionalCharge { get; set; }

        public int NumberOfRedShape { get; set; }

        public int NumberOfBlueShape { get; set; }

        public int NumberOfYellowShape { get; set; }

        public int TotalQuantityOfShape => NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;

        public int AdditionalChargeTotal => NumberOfRedShape * AdditionalCharge;

        public abstract int Total { get; }
    }
}
