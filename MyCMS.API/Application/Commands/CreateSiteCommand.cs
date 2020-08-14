using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCMS.API.Application.Commands
{
    public class CreateSiteCommand : IRequest<int>
    {
        public CreateSiteCommand(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
