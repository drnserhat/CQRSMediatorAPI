using CQRSMediatorAPI.Entites;
using CQRSMediatorAPI.MediatRRequests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace CQRSMediatorAPI.MediatRRequests.Handlers
{
	public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
	{
		private readonly FakeDataStore _fakeDataStore;
		public GetProductsHandler(FakeDataStore fakeDataStore)
		{
			_fakeDataStore = fakeDataStore;
		}
		public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
		{
			var result = await _fakeDataStore.GetAllProducts();
			return result;
		}
	}
}
