using DotNetCore.CAP;
using MediatR;
using Microsoft.Extensions.Logging;
using MyCMS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCMS.API.Application.IntegrationEvents
{
    public class SubscriberService : ISubscriberService, ICapSubscribe
    {
        IMediator _mediator;
        ILogger<SubscriberService> _logger;
        ITestRepository _testRepository;
        public SubscriberService(IMediator mediator, ILogger<SubscriberService> logger, ITestRepository testRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _testRepository = testRepository;
        }


        [CapSubscribe("SiteCreated")]
        public void SiteCreated(SiteCreatedIntegrationEvent @event)
        {
            //Do SomeThing
            _logger.LogInformation($"1.关注接收到 SiteCreated 集成事件，参数Id={@event.Id}");

            _testRepository.Add(new Domain.Test() { Name = "Test2" });  //测试失败
            var i = _testRepository.UnitOfWork.SaveChangesAsync().Result;

        }


        //[CapSubscribe("SiteCreated")]
        //public void SiteCreated2(SiteCreatedIntegrationEvent @event)
        //{
        //    //Do SomeThing
        //    _logger.LogInformation($"2.关注接收到 SiteCreated 集成事件，参数Id={@event.Id}");

        //}


    }
}
