namespace ESC.AdministrationCore.Application.DTOs;

public class ProductCreationDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }

}
