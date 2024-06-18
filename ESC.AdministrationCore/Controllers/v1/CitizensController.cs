using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ESC.AdministrationCore.Infraestructure;
using ESC.AdministrationCore.Entities.DbSet;
using EESC.AdministrationCore.Application.DTOs;

namespace ESC.AdministrationCore.Controllers.v1
{
    [Route("administration/v1/citizens")]
    [ApiController]

    public class CitizensController : ControllerBase
    {
        private readonly AdministrationCoreDbContext _context;
        private readonly IMapper _mapper;

        //inyección de dependencias 
        public CitizensController(AdministrationCoreDbContext Context, IMapper mapper)
        {
            _context = Context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CitizenDTO>>> Get()
        {
            var citizens = await _context.Citizens.ToListAsync();
            return _mapper.Map<List<CitizenDTO>>(citizens);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCitizenById(Guid id)
        {
            var citizen = await _context.Citizens.FirstOrDefaultAsync(x => x.Id == id);

            if (citizen == null)
                return NotFound("Registro no encontrado.");

            return (IActionResult)_mapper.Map<CitizenDTO>(citizen);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CitizenCreateDTO citizenCreateDTO)
        {
            var existe = await _context.Citizens.AnyAsync(x => x.DocumentNumber == citizenCreateDTO.DocumentNumber);
            if (existe)
                return BadRequest($"Ya existe un agente con el nro de documento {citizenCreateDTO.DocumentNumber}");

            var citizen = _mapper.Map<Citizen>(citizenCreateDTO);
            _context.Add(citizen);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
