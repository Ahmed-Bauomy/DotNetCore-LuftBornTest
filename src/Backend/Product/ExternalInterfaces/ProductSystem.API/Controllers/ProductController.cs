using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductSystem.Application.Features.Commands.CreateProduct;
using ProductSystem.Application.Features.Commands.DeleteProduct;
using ProductSystem.Application.Features.Commands.UpdateProduct;
using ProductSystem.Application.Features.Queries.GetProductsByCategory;
using ProductSystem.Application.Models;
using ProductSystem.Domain.Entities;
using System.Net;

namespace ProductSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProduct(CreateProductCommand product)
        {
            var result = await _mediator.Send(product);
            return Ok(result);
        }

        [HttpGet("{category}")]
        [ProducesResponseType(typeof(IEnumerable<ProductDTO>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByCategory(string category)
        {
            var query = new GetProductsByCategoryQuery(category);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand product)
        {
            await _mediator.Send(product);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleteCommand = new DeleteProductCommand(id);
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
