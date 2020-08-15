using MediatR;
using MyCMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCMS.API.Application.Commands
{
    public class CreateSiteCommand : IRequest<Result>
    {
        public CreateSiteCommand(string name, string domain)
        {
            Name = name;
            Domain = domain;
        }


        public string Name { get; private set; }
        public string Domain { get; private set; }
    }
}
