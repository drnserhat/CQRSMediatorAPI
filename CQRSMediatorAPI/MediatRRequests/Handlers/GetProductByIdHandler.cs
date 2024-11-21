using CQRSMediatorAPI.Entites;
using CQRSMediatorAPI.MediatRRequests.Queries;
using MediatR;

namespace CQRSMediatorAPI.MediatRRequests.Handlers
{
	public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
	{
		private readonly FakeDataStore _fakeDataStore;
		public GetProductByIdHandler(FakeDataStore fakeDataStore)
		{
			_fakeDataStore = fakeDataStore;
		}
		public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			var result = await _fakeDataStore.GetProductById(request.Id);
			return result;
		}
	}
}
