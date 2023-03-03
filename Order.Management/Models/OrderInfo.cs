using System;
using System.Collections.Generic;
using Order.Management.Services;

namespace Order.Management.Models
{
  public struct OrderInfo
  {
    public string Name { get; set; }
    public string Address { get; set; }
    public int OrderNumber { get; }
    public DateTime DueDate { get; set; }
    public List<Toy> Items { get; set; }

    public OrderInfo(string name, string address)
    {
        Name = name;
        Address = address;
        OrderNumber = CommonUtils.GetOrderNumber();
        // normally the due date depends on the order date
        // also, the date input is pretty tricky to implement in a console app
        // so I just hardcode it here
        DueDate = DateTime.Now.AddDays(14);
        Items = new List<Toy>();
    }
  }
}
