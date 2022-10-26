using ReportManager.Domain.Entities;

namespace ReportManager.Domain
{
    public class ReportEntity : BaseEntity
    {
        public int IdUser { get; set; }
        public string Report { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
