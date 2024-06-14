using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ESC.AdministrationCore.Infraestructure;
using ESC.AdministrationCore.Entities.DbSet;
using ESC.AdministrationCore.Application.DTOs;
using ESC.AdministrationCore.Infraestructure.Repositories.Contracts;


namespace ESC.AdministrationCore.Controllers.v1
{

    [Route("administration/v1/documenttypes")]
    [ApiController]
    public class DocumentTypesController : ControllerBase
    {
        private readonly AdministrationCoreDbContext _context;
        private readonly IDocumentTypeRepository _service;
        private readonly IMapper _mapper;

        //inyección de dependencias 
        public DocumentTypesController(AdministrationCoreDbContext Context, IDocumentTypeRepository Service, IMapper mapper )
        {
            _context = Context;
            _service = Service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentTypeDTO>>> Get()
        {

            //var documentTypes = await _context.DocumentTypes.ToListAsync();

            //return _mapper.Map<List<DocumentTypeDTO>>(documentTypes);
            
            var documentTypes = await _service.GetAll();
            return _mapper.Map<List<DocumentTypeDTO>>(documentTypes);
        }


        //[HttpGet]
        //[Route("{code}")]
        //public async Task<ActionResult<DocumentTypeDTO>> GetDocumentTypeByCode(string code)
        //{
        //    var documentType = await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Code == code);

        //    if (documentType == null)
        //        return NotFound("Registro no encontrado.");

        //    return _mapper.Map<DocumentTypeDTO>(documentType);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] DocumentTypeCreateDTO documentTypeCreateDTO)
        //{
        //    var documentType = _mapper.Map<DocumentType>(documentTypeCreateDTO);
        //    var existe = await _context.DocumentTypes.AnyAsync(x => x.Description == documentTypeCreateDTO.Description);

        //    if (existe)
        //        return BadRequest($"Ya existe un tipo de documento con el nombre {documentTypeCreateDTO.Description}");

        //    _context.Add(documentType);

        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

    }
}
