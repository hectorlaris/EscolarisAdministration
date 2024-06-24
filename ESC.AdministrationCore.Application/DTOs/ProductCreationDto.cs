using System.ComponentModel.DataAnnotations;

namespace ESC.AdministrationCore.Application.DTOs;

public class ProductCreationDto
{
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;
    public int supplierId { get; set; } = default!;
    public decimal UnitPrice { get; set; }

}


