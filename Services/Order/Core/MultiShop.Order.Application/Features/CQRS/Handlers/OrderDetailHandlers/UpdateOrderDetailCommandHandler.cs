using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _repository.GetByIDAsync(updateOrderDetailCommand.OrderDetailID);
            values.ProductID = updateOrderDetailCommand.ProductID;
            values.ProductName = updateOrderDetailCommand.ProductName;
            values.ProductPrice = updateOrderDetailCommand.ProductPrice;
            values.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            values.ProductAmount = updateOrderDetailCommand.ProductAmount;
            values.OrderingID = updateOrderDetailCommand.OrderingID;

            await _repository.UpdateAsync(values);
        }
    }
}
