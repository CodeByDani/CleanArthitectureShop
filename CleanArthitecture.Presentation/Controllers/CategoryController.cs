using CleanArthitecture.Application.Services.Category.Commands.AddCategory;
using CleanArthitecture.Application.Services.Category.Commands.DeleteCategory;
using CleanArthitecture.Application.Services.Category.Commands.UpdateCategory;
using CleanArthitecture.Application.Services.Category.Queries.GetAllCategory;
using CleanArthitecture.Application.Services.Category.Queries.GetCategory;
using CleanArthitecture.Presentation.DTO;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArthitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/category")]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetCategoryQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryRequest category)
        {

            var result = _mapper.Map<CategoryCommandAdd>(category);
            await _mediator.Send(result);
            return StatusCode(StatusCodes.Status201Created, "Category Successfully Added!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(CategoryRequest category, long id)
        {
            var result = _mapper.Map<UpdateCategoryCommand>(category);
            result = result with { Id = id };

            await _mediator.Send(result);
            return StatusCode(StatusCodes.Status200OK, "Category Successfully Updated!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(long id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return StatusCode(StatusCodes.Status200OK, "Category Successfully Deleted!");
        }

    }
}
