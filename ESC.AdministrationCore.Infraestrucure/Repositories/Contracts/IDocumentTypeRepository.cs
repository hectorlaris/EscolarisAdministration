using System.Threading.Tasks;
using ESC.AdministrationCore.Application.DTOs;
using ESC.AdministrationCore.Entities.DbSet;


namespace ESC.AdministrationCore.Infraestructure.Repositories.Contracts
{
	public interface IDocumentTypeRepository
	{
        Task<List<DocumentTypeDTO>> GetAll();
        //DocumentType GetById(Guid id);
        //void Add(DocumentType documentType);
        //void Update(DocumentType documentType);
        //void Delete(Guid id);
    }
}