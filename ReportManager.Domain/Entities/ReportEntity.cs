namespace ReportManager.Domain
{
    public class ReportEntity
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Report { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
