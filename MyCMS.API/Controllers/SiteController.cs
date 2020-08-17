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
        readonly ILogger<SiteController> _logger;
        public SiteController(IMediator mediator, ILogger<SiteController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 创建网站
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<dynamic> CreateSite([FromBody]CreateSiteCommand cmd)
        {
            _logger.LogInformation($"接收到接口请求/api/Site/CreateSite,参数 Name={cmd.Name} Domain={cmd.Domain}");
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

    }
}
