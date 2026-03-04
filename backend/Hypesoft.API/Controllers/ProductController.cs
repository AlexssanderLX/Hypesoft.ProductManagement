using Hypesoft.Application.Commands.Products;
using Hypesoft.Application.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hypesoft.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Metodo POST create
    [HttpPost]
    public async Task<IActionResult> Create(
    [FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(
            new GetProductsQuery(page, pageSize));

        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(
            new GetProductByIdQuery(id));

        return Ok(result);
    }
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("name is required");

        var result = await _mediator.Send(new SearchProductsByNameQuery(name));
        return Ok(result);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetByCategory(Guid categoryId)
    {
        var result = await _mediator.Send(
            new GetProductsByCategoryQuery(categoryId));

        return Ok(result);
    }

    [HttpGet("low-stock")]
    public async Task<IActionResult> GetLowStock()
    {
        var result = await _mediator.Send(
            new GetLowStockProductsQuery());

        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteProductCommand { Id = id });

        if (!result)
            return NotFound();

        return NoContent();
    }
    [HttpPatch("{id}/stock")]
    public async Task<IActionResult> UpdateStock(
    Guid id,
    [FromBody] int quantity)
    {
        var result = await _mediator.Send(new UpdateStockCommand
        {
            ProductId = id,
            Quantity = quantity
        });

        if (!result)
            return NotFound();

        return NoContent();
    }
}