using ESC.AdministrationCore.Entities.DbSet;
using ESC.AdministrationCore.Application.DTOs;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ESC.AdministrationCore.Application.Interfaces;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace ESC.AdministrationCore.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // instancias almacenadas que no cambia de valor = readonly
        private readonly AdministrationCoreDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProductRepository(AdministrationCoreDbContext Context,
                                           IDistributedCache Cache, ILogger<Product> Logger, IMapper Mapper)
        {
            _context = Context;
            _cache = Cache;
            _logger = Logger;
            _mapper = Mapper;
        }

        public async Task Add(ProductCreationDto request)
        {
            var product = new Entities.DbSet.Product(request.ProductName, request.ProductDescription, request.supplierId, request.UnitPrice);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            
            // invalidate cache for products, as new product is added
            var cacheKey = "products";
            _logger.LogInformation("invalidating cache for key: {CacheKey} from cache.", cacheKey);
            _cache.Remove(cacheKey);
        }
        public async Task<Entities.DbSet.Product> GetProductById(Guid id)
        {
            var cacheKey = $"product:{id}";
            _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);
            var product = await _cache.GetOrSetAsync(cacheKey,
                async () =>
                {
                    _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);
                    return await _context.Products.FindAsync(id)!;
                })!;
            return product!;
        }
        public async Task<List<Entities.DbSet.Product>> GetAll()
        {
            var cacheKey = "products";
            _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);
            var cacheOptions = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(20))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            var products = await _cache.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);
                    return await _context.Products.ToListAsync();
                },
                cacheOptions)!;
            return products!;
        }
    }
}