using CQRSMediatorAPI.Entites;
using CQRSMediatorAPI.MediatRRequests.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace CQRSMediatorAPI.MediatRRequests.Handlers
{
	public class EmailHandler : INotificationHandler<ProductAddedNotification>
	{
		private readonly FakeDataStore _fakeDataStore;
		public EmailHandler(FakeDataStore fakeDataStore)
		{
			_fakeDataStore = fakeDataStore;
		}
		public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
		{
			await _fakeDataStore.EventOccured(notification.product, "Email sent");
			await Task.CompletedTask;
		}
	}
}
