using MyCMS.Domain.SiteAggregate;
using MyCMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCMS.Infrastructure.Repositories
{
    public class SiteRepository : Repository<SiteInfo, int, DomainContext>, ISiteRepository
    {
        public SiteRepository(DomainContext context) : base(context)
        {
        }
    }


    public interface ISiteRepository : IRepository<SiteInfo, int>
    { }

}
