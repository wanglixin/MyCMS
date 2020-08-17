using MyCMS.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCMS.Domain
{
    public class Test : Entity<string>, IAggregateRoot
    {
        public string Name { get; set; }

        public Test()
        {
        }

        public Test(string name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
        }
    }
}
