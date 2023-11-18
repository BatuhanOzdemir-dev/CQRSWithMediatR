using DAL.CQRS.Commands.Request;
using DAL.CQRS.Commands.Response;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product productToDelete = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == request.Id);
            ApplicationDbContext.ProductList.Remove(productToDelete);
            return new DeleteProductCommandResponse()
            {
                IsSuccess = true,
            };
        }
    }
}
