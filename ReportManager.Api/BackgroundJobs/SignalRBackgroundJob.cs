using Microsoft.AspNetCore.SignalR;
using ReportManager.Api.Hubs;

namespace ReportManager.Api.BackgroundJobs
{
    public class SignalRBackgroundJob : BackgroundService
    {
        private readonly IHubContext<UpdateHub, IUpdateHub> _hubContext;
        public SignalRBackgroundJob(IHubContext<UpdateHub, IUpdateHub> hubContext)
        {
            _hubContext = hubContext;
        }
        protected override async Task ExecuteAsync(CancellationToken stopToken)
        {

            while (!stopToken.IsCancellationRequested)
            {
                var rnd = new Random();
                await _hubContext.Clients.All.UpdateReportsCount(rnd.Next(0, 100).ToString());

                await Task.Delay(1000);// 1000 is a delay timer for task delay
            }
        }
    }
}
