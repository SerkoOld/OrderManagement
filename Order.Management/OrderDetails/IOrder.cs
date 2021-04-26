using Order.Management.Shapes;
using System;

namespace Order.Management.OrderDetails
{
    public interface IOrder
    {
        Circle Circle { get; }
        CustomerInfo CustomerInfo { get; }
        DateTime DueDate { get; }
        int OrderNumber { get; }
        Square Square { get; }
        Triangle Triangle { get; }

        string PrintOrderDetails();
        decimal Total();
    }
}