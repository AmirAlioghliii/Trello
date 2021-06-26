using Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trello.Api.Hubs;
using Trello_.Data;

namespace Application.Workers
{
    public class WarningWorker : BackgroundService
    {

        private readonly IServiceProvider _serviceProvider;

        public WarningWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using (var scope = _serviceProvider.CreateScope())
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(10));
                         
                        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                        var accessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
                        SendMessageHub hub = new SendMessageHub(accessor);

                        var tasks = await unitOfWork.UserRepository.GetAllTasks();


                        foreach (var item in tasks)
                        {
                            if (DateTime.Now> item.TaskTime-TimeSpan.FromHours(1))
                            {
                                var user =await unitOfWork.UserRepository.GetUserById(item.UserId);
                                await hub.SendmessageToClient(user.ConnectionId,"Task Reject");
                            }

                            if (DateTime.Now > item.TaskTime)
                            {
                                var user = await unitOfWork.UserRepository.GetUserById(item.UserId);
                                await hub.SendmessageToClient(user.ConnectionId, "Task Reject");
                                await unitOfWork.AdminRepository.ChangeTaskStatus(item.Id, "Task Rejected");
                                item.Status = "Reject";
                                await unitOfWork.SaveChangesAsync();
                            }
                        }
                        
                       

                    }
                    catch (Exception)
                    {


                    }
                }



            }
        }
    }
}
