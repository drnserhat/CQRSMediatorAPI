using CQRSMediatorAPI.Entites;
using CQRSMediatorAPI.MediatRRequests.Notifications;
using MediatR;

namespace CQRSMediatorAPI.MediatRRequests.Handlers
{
	public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
	{
		private readonly FakeDataStore _fakeDataStore;
		public CacheInvalidationHandler(FakeDataStore fakeDataStore)
		{
				_fakeDataStore = fakeDataStore;
		}
		public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
		{
			await _fakeDataStore.EventOccured(notification.product, "Cache Invalidation");
			await Task.CompletedTask;
		}
	}
}
