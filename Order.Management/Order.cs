using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Order
    {
        private int OrderNumber;
        public CustomerInfo CustomerInfo { get; set; }
        public Order(CustomerInfo customerInfo)
        {
            this.CustomerInfo = customerInfo;
            //this.OrderNumber = new Random().Next();
        }

        public override string ToString()
        {
            return "Name: " + CustomerInfo.Name + " Address: " + CustomerInfo.Address + " Due Date: " + CustomerInfo.DueDate + " Order #: " + OrderNumber;
        }
    }
}
