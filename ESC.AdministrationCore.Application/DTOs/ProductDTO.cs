namespace ESC.AdministrationCore.Application.DTOs
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public string ProductDescription { get; set; } = default!;
        public decimal UnitPrice { get; set; }

    }
}

