using DotNetCore.CAP;
using MyCMS.Infrastructure.Core.Behaviors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCMS.Infrastructure
{
    public class DomainContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<DomainContext, TRequest, TResponse>
    {
        public DomainContextTransactionBehavior(DomainContext dbContext, ICapPublisher capBus,ILogger<DomainContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, capBus, logger)
        {
        }
    }
}
