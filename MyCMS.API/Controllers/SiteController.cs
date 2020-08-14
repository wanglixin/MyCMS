using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpPost]
        public async Task<long> CreateOrder([FromBody]CreateOrderCommand cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

    }
}
