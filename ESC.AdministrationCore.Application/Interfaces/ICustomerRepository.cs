using ESC.AdministrationCore.Entities.DbSet; // To use Customer.

namespace ESC.AdministrationCore.Application.Interfaces;

public interface ICustomerRepository
{
  Task<Customer?> CreateAsync(Customer c);
  Task<Customer[]> RetrieveAllAsync();
  Task<Customer?> RetrieveAsync(string id);
  Task<Customer?> UpdateAsync(Customer c);
  Task<bool?> DeleteAsync(string id);
}
