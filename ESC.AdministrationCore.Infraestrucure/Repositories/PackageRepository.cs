using Microsoft.EntityFrameworkCore.ChangeTracking; // To use EntityEntry<T>.
using Microsoft.EntityFrameworkCore;                // To use ToArrayAsync.
using System.Threading.Tasks;


using ESC.AdministrationCore.Infraestructure;
using ESC.AdministrationCore.Entities.DbSet;



namespace ESC.AdministrationCore.Infraestructure.Repositories;

public class PackageRepository : IPackageRepository
{
	private AdministrationCoreDbContext _db;

	public PackageRepository(AdministrationCoreDbContext db)
	{
		_db = db;
	}

	public Task<DocumentType[]> RetrieveAllAsync()
	{
		return _db.DocumentTypes.ToArrayAsync();
	}


}