using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCMS.API.Application.IntegrationEvents
{
    /// <summary>
    /// 站点创建事件（集成），通过该对象去传递
    /// </summary>
    public class SiteCreatedIntegrationEvent
    {
        public SiteCreatedIntegrationEvent(int id) => Id = id;
        public int Id { get; }
    }
}
