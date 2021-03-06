﻿using DotNetCore.CAP;
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
        readonly ISiteRepository _siteRepository;
        readonly ITestRepository _testRepository;
        readonly ICapPublisher _capPublisher;
        public CreateSiteCommandHandler(ISiteRepository siteRepository, ITestRepository testRepository, ICapPublisher capPublisher
            )
        {
            _siteRepository = siteRepository;
            _testRepository = testRepository;
            _capPublisher = capPublisher;
        }


        public async Task<Result> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {
            if (await _siteRepository.AnyAsync())
            {
                return Result<int>.Failure(0, "请不要重复创建");
            }
            var site = new SiteInfo(request.Name, request.Domain);
            await _siteRepository.AddAsync(site);
            await _siteRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
           // await _testRepository.AddAsync(new Domain.Test() { Name = "Testt" });
          
             await _testRepository.AddAsync(new Domain.Test("Testt"));
            await _testRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);



            return Result<int>.Success(site.Id, "创建成功");
        }
    }
}