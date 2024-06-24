using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESC.AdministrationCore.Entities.DbSet;
public class Product
{
    [Key]
    public Guid ProductId { get; set; }
    
    [StringLength(40)]
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    [StringLength(20)]
    public string? QuantityPerUnit { get; set; }

    [Column(TypeName = "money")]
    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    [Required]
    public bool? Discontinued { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("SupplierId")]
    [InverseProperty("Products")]
    public virtual Supplier? Supplier { get; set; }

    // Parameterless constructor for EF Core
    private Product() { }

    public Product(string name, string description, decimal price)
    {
        ProductId = Guid.NewGuid();
        ProductName = name;
        ProductDescription = description;
        UnitPrice = price;
    }
}