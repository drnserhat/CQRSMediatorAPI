using CQRSMediatorAPI.Entites;
using CQRSMediatorAPI.MediatRRequests.Commands;
using CQRSMediatorAPI.MediatRRequests.Notifications;
using CQRSMediatorAPI.MediatRRequests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatorAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ProductController(IMediator mediator)
		{
				_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			var products  = await _mediator.Send(new GetProductsQuery());
			return Ok(products);
		}

		[HttpPost]
		public async Task<ActionResult> AddProduct([FromBody] Product product)
		{
			var productToReturn = await _mediator.Send(new AddProductCommand(product));
			await _mediator.Publish(new ProductAddedNotification(productToReturn));	
			return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);

		}

		[HttpGet("{id:int}",Name ="GetProductById")]
		public async Task<IActionResult> GetProductById(int id)
		{
			var product = _mediator.Send(new GetProductByIdQuery(id));
			return Ok(product);
		}
	}
}
