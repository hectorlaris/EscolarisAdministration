using System.Threading.Tasks;
using ESC.AdministrationCore.Entities.DbSet;

namespace ESC.AdministrationCore.Infraestructure.Repositories
{
	public interface IPackageRepository
	{
		Task<DocumentType[]> RetrieveAllAsync();
	}
}