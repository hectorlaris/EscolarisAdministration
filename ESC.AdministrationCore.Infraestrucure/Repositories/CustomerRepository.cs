using Microsoft.EntityFrameworkCore.ChangeTracking; // To use EntityEntry<T>.
using ESC.AdministrationCore.Entities.DbSet; // To use Customer.
using ESC.AdministrationCore.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory; // To use IMemoryCache.
using Microsoft.EntityFrameworkCore; // To use ToArrayAsync.

namespace ESC.AdministrationCore.Infraestructure.Repositories;

public class CustomerRepository : ICustomerRepository
{

    // instancias almacenadas que no cambia de valor = readonly
    // Use an instance data context field because it should not be
    // cached due to the data context having internal caching.
    private readonly AdministrationCoreDbContext _context;
    private readonly IMemoryCache _memoryCache;

    private readonly MemoryCacheEntryOptions _cacheEntryOptions = new()
    {
        SlidingExpiration = TimeSpan.FromMinutes(30)
    };

    public CustomerRepository(AdministrationCoreDbContext Context,
                             IMemoryCache memoryCache)
    {
            _context = Context;
        _memoryCache = memoryCache;
    }

    public async Task<Customer?> CreateAsync(Customer c)
    {
        c.CustomerId = c.CustomerId.ToUpper(); // Normalize to uppercase.

        // Add to database using EF Core.
        EntityEntry<Customer> added = await _context.Customers.AddAsync(c);

        int affected = await _context.SaveChangesAsync();
        if (affected == 1)
        {
            // If saved to database then store in cache.
            _memoryCache.Set(c.CustomerId, c, _cacheEntryOptions);
            return c;
        }
        return null;
    }

    public Task<Customer[]> RetrieveAllAsync()
    {
    return _context.Customers.ToArrayAsync();
    }

    public Task<Customer?> RetrieveAsync(string id)
    {
        id = id.ToUpper(); // Normalize to uppercase.

        // Try to get from cache first.
        if (_memoryCache.TryGetValue(id, out Customer? fromCache))
            return Task.FromResult(fromCache);

        // If not in cache then try to get from database.
        Customer? fromDb = _context.Customers.FirstOrDefault(c => c.CustomerId == id);

        // If not in database then return null result.
        if (fromDb is null) return Task.FromResult(fromDb);

        // If in database then store in cache and return customer.
        _memoryCache.Set(fromDb.CustomerId, fromDb, _cacheEntryOptions);

        return Task.FromResult(fromDb)!;
    }

    public async Task<Customer?> UpdateAsync(Customer c)
    {
        c.CustomerId = c.CustomerId.ToUpper();

        _context.Customers.Update(c);

        int affected = await _context.SaveChangesAsync();
        if (affected == 1)
        {
            _memoryCache.Set(c.CustomerId, c, _cacheEntryOptions);
            return c;
        }
        return null;
    }

    public async Task<bool?> DeleteAsync(string id)
    {
    id = id.ToUpper();

    Customer? c = await _context.Customers.FindAsync(id);
    if (c is null) return null;

    _context.Customers.Remove(c);
    int affected = await _context.SaveChangesAsync();
    if (affected == 1)
    {
        _memoryCache.Remove(c.CustomerId);
        return true;
    }
    return null;
    }
}
