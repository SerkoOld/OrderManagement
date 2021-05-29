namespace Order.Management.Reports
{
    public interface IReport
    {
        public string ReportName { get; set; }
        public int TableWidth { get; set; }
        public void GenerateReport();
    }
}