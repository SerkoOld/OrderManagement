using System;
using System.Collections.Generic;

namespace Order.Management.Models
{
  public struct OrderInfo
  {
    public string Name { get; set; }
    public string Address { get; set; }
    public int OrderNumber { get; set; }
    public DateTime DueDate { get; set; }
    public List<Toy> Items { get; set; }
  }
}
