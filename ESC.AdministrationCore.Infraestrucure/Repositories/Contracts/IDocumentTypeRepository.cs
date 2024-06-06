using System.Threading.Tasks;
using ESC.AdministrationCore.Entities.DbSet;


namespace ESC.AdministrationCore.Infraestructure.Repositories.Contracts
{
	public interface IDocumentTypeRepository
	{
		Task<DocumentType[]> RetrieveAllAsync();
	}
}