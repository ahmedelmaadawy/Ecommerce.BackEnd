﻿namespace Ecommerce.Core.DTO
{
    public record ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<PhotoDTO> Photos { get; set; }
        public string CategoryName { get; set; }
    }

    public record PhotoDTO
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
    }
}
