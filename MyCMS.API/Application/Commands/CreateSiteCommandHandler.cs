using DotNetCore.CAP;
using MediatR;
using MyCMS.Domain.SiteAggregate;
using MyCMS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyCMS.API.Application.Commands
{
    public class CreateSiteCommandHandler : IRequestHandler<CreateSiteCommand, int>
    {
        ISiteRepository _siteRepository;
        ICapPublisher _capPublisher;
        public CreateSiteCommandHandler(ISiteRepository siteRepository, ICapPublisher capPublisher
            )
        {
            _siteRepository = siteRepository;
            _capPublisher = capPublisher;
        }


        public async Task<int> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {

            // var address = new Address("wen san lu", "hangzhou", "310000");
            var site = new SiteInfo("测试", "http://www.baidu.com");

            _siteRepository.Add(site);
            await _siteRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return site.Id;
        }
    }
}