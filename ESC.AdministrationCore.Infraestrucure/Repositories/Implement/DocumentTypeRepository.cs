
using Microsoft.EntityFrameworkCore.ChangeTracking; // To use EntityEntry<T>.
using Microsoft.EntityFrameworkCore;                // To use ToArrayAsync.
using AutoMapper;

using ESC.AdministrationCore.Entities.DbSet;
using ESC.AdministrationCore.Application.DTOs;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ESC.AdministrationCore.Infraestructure.Repositories.Contracts;


namespace ESC.AdministrationCore.Infraestructure.Repositories.Implement
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        // instancias almacenadas que no cambia de valor = readonly
        private readonly AdministrationCoreDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;


        //constructor
        public DocumentTypeRepository(AdministrationCoreDbContext Context,
                                          IMemoryCache Cache, ILogger<DocumentType> Logger, IMapper Mapper)
        {
            _context = Context;
            _cache = Cache;
            _logger = Logger;
            _mapper = Mapper;
        }

        public async Task<List<DocumentTypeDTO>> GetAll()
        {
            var cacheKey = "documentTypes";

            _logger.LogInformation("fetching data for key: {CacheKey} from cache.", cacheKey);

            if (!_cache.TryGetValue(cacheKey, out List<DocumentType>? documentTypes))
            {
                _logger.LogInformation("cache miss. fetching data for key: {CacheKey} from database.", cacheKey);

                documentTypes = await _context.DocumentTypes.ToListAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(20))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2))
                    .SetPriority(CacheItemPriority.NeverRemove)
                    .SetSize(2048);
                _logger.LogInformation("setting data for key: {CacheKey} to cache.", cacheKey);
                _cache.Set(cacheKey, documentTypes, cacheOptions);
            }
            else
            {
                _logger.LogInformation("cache hit for key: {CacheKey}.", cacheKey);
            }

            //return documentTypes;
            return _mapper.Map<List<DocumentTypeDTO>>(documentTypes);
        }

        //public DocumentType GetById(Guid id)
        //{
        //    // Implementation here...
        //}

        //public void Add(DocumentType documentType)
        //{
        //    // Implementation here...
        //}

        //public void Update(DocumentType documentType)
        //{
        //    // Implementation here...
        //}

        //public void Delete(Guid id)
        //{
        //    // Implementation here...
        //}
    }
}