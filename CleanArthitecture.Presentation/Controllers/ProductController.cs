using CleanArthitecture.Application.Services.Product.Commands.AddProduct;
using CleanArthitecture.Application.Services.Product.Commands.DeleteProduct;
using CleanArthitecture.Application.Services.Product.Commands.UpdateProduct;
using CleanArthitecture.Application.Services.Product.Queries.GetAllProduct;
using CleanArthitecture.Application.Services.Product.Queries.GetAllProductByCategoryId;
using CleanArthitecture.Application.Services.Product.Queries.GetProduct;
using CleanArthitecture.Presentation.DTO;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArthitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/product")]
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetProductQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _mediator.Send(new GetAllProductQuery());
            return Ok(result);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetAllByCategoryById(long id)
        {

            var result = await _mediator.Send(new GetAllProductByCategoryIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductRequest product)
        {

            var result = _mapper.Map<AddProductCommand>(product);
            await _mediator.Send(result);
            return StatusCode(StatusCodes.Status201Created, "Product Successfully Added!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(ProductRequest product, long id)
        {
            var result = _mapper.Map<UpdateProductCommand>(product);
            result = result with { Id = id };

            await _mediator.Send(result);
            return StatusCode(StatusCodes.Status200OK, "Product Successfully Updated!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(long id)
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return StatusCode(StatusCodes.Status200OK, "Product Successfully Deleted!");
        }
    }
}
