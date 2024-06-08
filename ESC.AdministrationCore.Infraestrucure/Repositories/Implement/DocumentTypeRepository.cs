using Microsoft.EntityFrameworkCore.ChangeTracking; // To use EntityEntry<T>.
using Microsoft.EntityFrameworkCore;                // To use ToArrayAsync.
using System.Threading.Tasks;
using ESC.AdministrationCore.Entities.DbSet;
using ESC.AdministrationCore.Infraestructure.Repositories.Contracts;
using ESC.AdministrationCore.Application;

namespace ESC.AdministrationCore.Infraestructure.Repositories.Implement;

public class DocumentTypeRepository : IDocumentTypeRepository
{
	private AdministrationCoreDbContext _db;

	public DocumentTypeRepository(AdministrationCoreDbContext db)
	{
		_db = db;
	}

	public Task<DocumentType[]> RetrieveAllAsync()
	{
		return _db.DocumentTypes.ToArrayAsync();
	}

}