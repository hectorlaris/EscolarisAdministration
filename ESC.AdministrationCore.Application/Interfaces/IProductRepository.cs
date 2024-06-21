using ESC.AdministrationCore.Entities.DbSet;
using ESC.AdministrationCore.Application.DTOs;

namespace ESC.AdministrationCore.Application.Interfaces;
public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task<Product> GetProductById(Guid id);
    Task Add(ProductCreationDto product);
}