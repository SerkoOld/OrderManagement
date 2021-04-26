namespace Order.Management.OrderDetails
{
    public class CustomerInfo
    {
        public string Name { get; }
        public string Address { get; }

        public CustomerInfo(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
