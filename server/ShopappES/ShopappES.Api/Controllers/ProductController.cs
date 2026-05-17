using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Product.Commands;
using ShopappES.Application.Features.Product.DTOs;
using ShopappES.Application.Features.Product.Queries;

namespace ShopappES.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<ProductDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery { Id = id });
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProductRequestDto dto)
    {
        var command = new CreateProductCommand
        {
            ProductName = dto.ProductName,
            ProductDescription = dto.ProductDescription,
            Price = dto.Price,
            DiscountPrice = dto.DiscountPrice,
            StockQuantity = dto.StockQuantity,
            ProductImage = dto.ProductImage,
            Images = dto.Images,
            Thumbnail = dto.Thumbnail,
            SKU = dto.SKU,
            CategoryId = dto.CategoryId,
            IsActive = dto.IsActive,
            IsFeatured = dto.IsFeatured,
            Brand = dto.Brand,
            Weight = dto.Weight,
            Dimensions = dto.Dimensions
        };

        var result = await _mediator.Send(command);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductRequestDto dto)
    {
        var command = new UpdateProductCommand
        {
            Id = id,
            ProductName = dto.ProductName,
            ProductDescription = dto.ProductDescription,
            Price = dto.Price,
            DiscountPrice = dto.DiscountPrice,
            StockQuantity = dto.StockQuantity,
            ProductImage = dto.ProductImage,
            Images = dto.Images,
            Thumbnail = dto.Thumbnail,
            SKU = dto.SKU,
            CategoryId = dto.CategoryId,
            IsActive = dto.IsActive,
            IsFeatured = dto.IsFeatured,
            Brand = dto.Brand,
            Weight = dto.Weight,
            Dimensions = dto.Dimensions
        };

        var result = await _mediator.Send(command);
        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteProductCommand { Id = id });
        return StatusCode(result.StatusCode, result);
    }
}
