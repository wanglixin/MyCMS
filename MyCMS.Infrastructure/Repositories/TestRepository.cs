using MyCMS.Domain;
using MyCMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCMS.Infrastructure.Repositories
{
    public class TestRepository : Repository<Test, string, DomainContext>, ITestRepository
    {
        public TestRepository(DomainContext context) : base(context)
        {
        }
    }

    public interface ITestRepository : IRepository<Test, string>
    { }

}
