using CQRSMediatorAPI.Entites;
using MediatR;

namespace CQRSMediatorAPI.MediatRRequests.Queries
{
	public record GetProductsQuery() : IRequest<IEnumerable<Product>>;

}
