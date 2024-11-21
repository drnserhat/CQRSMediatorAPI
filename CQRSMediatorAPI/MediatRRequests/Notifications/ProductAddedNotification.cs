using CQRSMediatorAPI.Entites;
using MediatR;

namespace CQRSMediatorAPI.MediatRRequests.Notifications
{
	public record ProductAddedNotification(Product product)
	:INotification;
	
}
