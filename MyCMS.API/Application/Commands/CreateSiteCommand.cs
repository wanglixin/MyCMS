using MediatR;
using MyCMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage ="名称不能为空")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "域名不能为空")]
        public string Domain { get; private set; }
    }
}
