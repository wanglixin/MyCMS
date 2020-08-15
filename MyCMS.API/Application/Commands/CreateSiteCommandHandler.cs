using DotNetCore.CAP;
using MediatR;
using MyCMS.Domain.SiteAggregate;
using MyCMS.Infrastructure.Core;
using MyCMS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyCMS.API.Application.Commands
{
    public class CreateSiteCommandHandler : IRequestHandler<CreateSiteCommand, Result>
    {
        ISiteRepository _siteRepository;
        ICapPublisher _capPublisher;
        public CreateSiteCommandHandler(ISiteRepository siteRepository, ICapPublisher capPublisher
            )
        {
            _siteRepository = siteRepository;
            _capPublisher = capPublisher;
        }


        public async Task<Result> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {
            var site = new SiteInfo(request.Name,request.Domain);
            _siteRepository.Add(site);
            await _siteRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return Result<int>.Success(site.Id);
        }
    }
}