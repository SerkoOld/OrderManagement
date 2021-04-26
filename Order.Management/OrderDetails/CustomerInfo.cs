namespace Order.Management.OrderDetails
{
    public class CustomerInfo
    {
        public CustomerInfo(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; }
        public string Address { get; }
    }
}
