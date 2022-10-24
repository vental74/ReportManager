using ReportManager.Application.Model;
using ReportManager.Application.Services;

namespace ReportManager.Api.BackgroundJobs
{
    public class CreatingReportJob : BackgroundService
    {
        private readonly ReportService _reportService;
        private readonly List<string> NamesList = new List<string> {"pidaras","gandon","chmo","petuch","loh","gavno sobach'e","yebak"};

        public CreatingReportJob(ReportService reportService)
        {
            _reportService = reportService;
        }

        private async Task DoWork()
        {
            var rnd = new Random();
            var item = new ReportModel
            {
                Report = "autoJob" + rnd.Next(0, 100),
                TimeStamp = DateTime.Now,
                UserName = NamesList[rnd.Next(0, NamesList.Count)]
            };
            await _reportService.AddReport(item);
        }

        protected override async Task ExecuteAsync(CancellationToken stopToken)
        {
            while (!stopToken.IsCancellationRequested)
            {
                await DoWork();

                await Task.Delay(100000);// 1000 is a delay timer for task delay
            }
        }


    }
}
