namespace ReportManager.Api.Hubs
{
    public interface IUpdateHub
    {
        Task UpdateReportsCount(string text);
    }
}
