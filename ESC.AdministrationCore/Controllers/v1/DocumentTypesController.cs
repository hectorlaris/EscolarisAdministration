using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ESC.AdministrationCore.Infraestructure;
using ESC.AdministrationCore.Entities.DbSet;
using ESC.AdministrationCore.Application.DTOs;


namespace ESC.AdministrationCore.Controllers.v1
{
    [ApiController]
    [Route("administration/v1/documenttypes")]
   
    public class DocumentTypesController : ControllerBase
    {
        private readonly AdministrationCoreDbContext _context;
        private readonly IMapper _mapper;

        public DocumentTypesController(AdministrationCoreDbContext Context,
                                       IMapper mapper )
        {
            _context = Context;
            _mapper = mapper;
        }


        //private readonly IDocumentTypeRepository _repo;

        //// Constructor injects repository registered in Program.cs.
        //public DocumentTypesController(IDocumentTypeRepository repo)
        //{
        //    _repo = repo;
        //}

        //[HttpGet()]
        //[ProducesResponseType(typeof(IEnumerable<DocumentType>), 200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        //public async Task<IEnumerable<DocumentType>> GetDocumentTypes()
        //{
        //    return (await _repo.RetrieveAllAsync());

        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DocumentTypeCreateDTO documentTypeCreateDTO)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeCreateDTO);
            var existe = await _context.DocumentTypes.AnyAsync(x => x.Description == documentTypeCreateDTO.Description);

            if (existe)
                return BadRequest($"Ya existe un tipo de documento con el nombre {documentTypeCreateDTO.Description}");

            _context.Add(documentType);
            
            await _context.SaveChangesAsync();
            
            return Ok();
        }

    }
}
