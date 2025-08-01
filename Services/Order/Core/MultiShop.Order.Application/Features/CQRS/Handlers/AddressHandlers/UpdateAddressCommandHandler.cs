﻿using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _repository.GetByIDAsync(updateAddressCommand.AddressID);
            values.UserID = updateAddressCommand.UserID;
            values.District = updateAddressCommand.District;
            values.City = updateAddressCommand.City;
            values.Detail1 = updateAddressCommand.Detail;
            await _repository.UpdateAsync(values);
        }
    }
}
