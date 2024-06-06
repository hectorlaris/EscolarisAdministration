using Microsoft.AspNetCore.Mvc;
using ESC.AdministrationCore.Infraestructure.Repositories.Contracts;
using ESC.AdministrationCore.Entities.DbSet;


namespace ESC.AdministrationCore.Controllers.v1
{
    [Route("administration/v1/documenttypes")]
    [ApiController]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IDocumentTypeRepository _repo;

        // Constructor injects repository registered in Program.cs.
        public DocumentTypesController(IDocumentTypeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<DocumentType>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]


        public async Task<IEnumerable<DocumentType>> GetDocumentTypes()
        {
            return (await _repo.RetrieveAllAsync());
                 
        }
    }
}
