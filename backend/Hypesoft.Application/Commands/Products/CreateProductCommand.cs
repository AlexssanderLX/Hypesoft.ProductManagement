using MediatR;
using Hypesoft.Application.DTOs;

namespace Hypesoft.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public int StockQuantity { get; set; }
    }
}