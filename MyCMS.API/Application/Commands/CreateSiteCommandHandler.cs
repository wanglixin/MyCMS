using DotNetCore.CAP;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyCMS.API.Application.Commands
{
    public class CreateSiteCommandHandler : IRequestHandler<CreateSiteCommand, int>
    {
       // IOrderRepository _orderRepository;
       // ICapPublisher _capPublisher;
        public CreateSiteCommandHandler( //IOrderRepository orderRepository, 
            //ICapPublisher capPublisher
            )
        {
           // _orderRepository = orderRepository;
           // _capPublisher = capPublisher;
        }


        public async Task<int> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {

            // var address = new Address("wen san lu", "hangzhou", "310000");
            //  var order = new Order("xiaohong1999", "xiaohong", 25, address);

            // _orderRepository.Add(order);
            //  await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return 110;
        }
    }
}