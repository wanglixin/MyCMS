using MyCMS.Domain.Abstractions;
using MyCMS.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCMS.Domain.SiteAggregate
{
    public class SiteInfo : Entity<int>, IAggregateRoot
    {

        /// <summary>
        /// 站点名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; private set; }

        /// <summary>
        /// 描述 介绍
        /// </summary>
        public string Desc { get; set; }


        protected SiteInfo() { }

        public SiteInfo(string name,string domain)
        {
            this.Name = name;
            this.Domain = domain;
            this.AddDomainEvent(new SiteCreatedDomainEvent(this));
        }

        public void ChangeName(string Name)
        {
            this.Name = Name;
            //this.AddDomainEvent(new OrderAddressChangedDomainEvent(this));
        }
    }
}
