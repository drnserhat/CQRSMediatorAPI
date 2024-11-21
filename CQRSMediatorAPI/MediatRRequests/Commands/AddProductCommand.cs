using CQRSMediatorAPI.Entites;
using MediatR;

namespace CQRSMediatorAPI.MediatRRequests.Commands
{
	public record AddProductCommand(Product Product) : IRequest<Product>;


}
