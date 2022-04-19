namespace Order.Management.Reports
{
    public abstract class Report
    {
        public Order Order { get;}

        public Report(Order order)
        {
            Order = order;
        }

        public abstract void GenerateReport();
    }
}
