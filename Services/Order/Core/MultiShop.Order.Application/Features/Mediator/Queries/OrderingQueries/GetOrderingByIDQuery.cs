using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIDQuery : IRequest<GetOrderingByIDQueryResult> //Tek bir değer döndürecek
    {
        public int ID { get; set; }
        public GetOrderingByIDQuery(int id)
        {
            ID = id;
        }
    }
}
