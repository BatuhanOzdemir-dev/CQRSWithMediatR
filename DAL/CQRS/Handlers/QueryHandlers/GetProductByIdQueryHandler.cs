using DAL.CQRS.Queries.Request;
using DAL.CQRS.Queries.Response;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CQRS.Handlers.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == request.Id);
            return new GetProductByIdQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                CreateTime = product.CreateTime
            };
        }
    }
}
