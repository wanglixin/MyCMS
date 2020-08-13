using MyCMS.Domain.Abstractions;
using MyCMS.Domain.SiteAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCMS.Domain.Events
{
    public class SiteCreatedDomainEvent : IDomainEvent
    {
        public SiteInfo Site { get; private set; }
        public SiteCreatedDomainEvent(SiteInfo site)
        {
            this.Site = site;
        }
    }
}
