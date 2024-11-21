using CQRSMediatorAPI.Entites;
using MediatR;

namespace CQRSMediatorAPI.MediatRRequests.Queries
{
	public record GetProductByIdQuery(int Id):IRequest<Product>;
	
}
