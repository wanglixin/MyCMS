//using MyCMS.Domain.OrderAggregate;

//using MyCMS.API.Application.IntegrationEvents;
using MyCMS.Infrastructure;
//using MyCMS.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using MyCMS.Domain.SiteAggregate;
using MyCMS.Infrastructure.Repositories;
using MyCMS.API.Application.IntegrationEvents;
using Microsoft.Extensions.Logging;
using DotNetCore.CAP.Messages;

namespace MyCMS.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DomainContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(SiteInfo).Assembly, typeof(Program).Assembly);
        }


        public static IServiceCollection AddDomainContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            return services.AddDbContext<DomainContext>(optionsAction);
        }

        //public static IServiceCollection AddInMemoryDomainContext(this IServiceCollection services)
        //{
        //    return services.AddDomainContext(builder => builder.UseInMemoryDatabase("domanContextDatabase"));
        //}

        public static IServiceCollection AddMySqlDomainContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDomainContext(builder =>
            {
                builder.UseMySql(connectionString);
            });
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            return services;
        }



        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISubscriberService, SubscriberService>();
            services.AddCap(options =>
            {
                options.UseEntityFramework<DomainContext>();

                options.UseRabbitMQ(options =>
                {
                    configuration.GetSection("RabbitMQ").Bind(options);
                    //options.Port
                });
                options.FailedRetryCount = 20; //重试20次结束
                options.FailedThresholdCallback = failed =>
                {
                    var logger = failed.ServiceProvider.GetService<ILogger>();
                    logger.LogInformation($@"A message of type {failed.MessageType} failed after executing {options.FailedRetryCount} several times, 
                        requiring manual troubleshooting. Message name: {failed.Message.GetName()}");
                };
                options.UseDashboard();
            });

            return services;
        }
    }
}
