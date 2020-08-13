using MyCMS.Domain.Abstractions;
using MyCMS.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCMS.Domain.SiteAggregate
{
    public class SiteInfo : Entity<int>, IAggregateRoot
    {
        public string Name { get; private set; }

        protected SiteInfo() { }

        public SiteInfo(string Name)
        {
            this.Name = Name;
            this.AddDomainEvent(new SiteCreatedDomainEvent(this));
        }
    }
}
