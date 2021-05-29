using System;
using System.Diagnostics.CodeAnalysis;

namespace Order.Management
{
    public class CustomerInfo
    {
        public string Name { get; }
        public string Address { get; }
        public DateTime DueDate { get; }

        public CustomerInfo([NotNull] string customerName, [NotNull] string address, [NotNull] string dueDate)
        {
            Name = customerName;
            Address = address;
            DueDate = DateTime.Parse(dueDate);
        }
    }
}