namespace Order.Management.Reports
{
    public abstract class BaseReport : IReport
    {
        private CustomerInfo CustomerInfo { get; }
        private Order Order { get; }

        public BaseReport(CustomerInfo customerInfo, Order order)
        {
            CustomerInfo = customerInfo;
            Order = order;
        }

        public abstract void GenerateReport();

        protected static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', width)
                : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}