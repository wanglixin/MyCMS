using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using MyCMS.API.Application.IntegrationEvents;
using MyCMS.Domain.Abstractions;
using MyCMS.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyCMS.API.Application.DomainEventHandlers
{
    public class SiteCreatedDomainEventHandler : IDomainEventHandler<SiteCreatedDomainEvent>
    {
        ICapPublisher _capPublisher;
        ILogger<SiteCreatedDomainEventHandler> _logger;
        public SiteCreatedDomainEventHandler(ICapPublisher capPublisher, ILogger<SiteCreatedDomainEventHandler> logger)
        {
            _capPublisher = capPublisher;
            _logger = logger;
        }

        public async Task Handle(SiteCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("_capPublisher.PublishAsync(\"SiteCreated\", new SiteCreatedIntegrationEvent(notification.Site.Id)) 接收站点创建事件，并发送出去，让关注该事件SiteCreated的人接收执行自己的业务");
            await _capPublisher.PublishAsync("SiteCreated", new SiteCreatedIntegrationEvent(notification.Site.Id));
        }

    }
}