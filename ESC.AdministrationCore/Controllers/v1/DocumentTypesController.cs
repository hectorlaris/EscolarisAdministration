using ESC.AdministrationCore.Infraestructure;
using ESC.AdministrationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using ESC.AdministrationCore.Infraestructure.Repositories;
using ESC.AdministrationCore.Entities.DbSet;


namespace ESC.AdministrationCore.Controllers.v1
{
    [Route("administration/v1/documenttypes")]
    [ApiController]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IPackageRepository _repo;

        // Constructor injects repository registered in Program.cs.
        public DocumentTypesController(IPackageRepository repo)
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
