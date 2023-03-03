namespace Order.Management.Models
{
    public struct InvoiceItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Sum { get; set; }
    }

    public struct Invoice
    {
        public InvoiceItem[] Items { get; set; }
        public decimal Total { get; set; }
    }
}
