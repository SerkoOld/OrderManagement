using System;

namespace Order.Management
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DueDate { get; set; }

        public Customer(string name, string address, string dueDate)
        {
            Name = name;
            Address = address;
            DueDate = DateTime.Parse(dueDate);
        }
    }
}
