using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Infrastructure.Services.Quartz;

public class DailyJob : IJob
{
    private readonly IServiceProvider _serviceProvider;

    public DailyJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            //    var myService = scope.ServiceProvider.GetRequiredService<IMyService>();

            //    var data = await myService.GetDataAsync();
            //    var result = myService.PerformLogic(data);
            //    await myService.CallAnotherService(result);
        }
}
}