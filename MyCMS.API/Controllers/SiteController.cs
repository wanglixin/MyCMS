using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCMS.API.Application.Commands;

namespace MyCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SiteController : ControllerBase
    {
        IMediator _mediator;

        public SiteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 创建网站
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<dynamic> CreateSite([FromBody]CreateSiteCommand cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

    }
}
