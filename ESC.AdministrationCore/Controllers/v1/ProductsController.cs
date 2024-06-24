using AutoMapper;
using ESC.AdministrationCore.Application.DTOs;
using ESC.AdministrationCore.Application.Interfaces;
using ESC.AdministrationCore.Entities.DbSet;
using ESC.AdministrationCore.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESC.AdministrationCore.Controllers.v1
{
    [Route("administration/v1/products")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly AdministrationCoreDbContext _context;
        private readonly IProductRepository _service;
        private readonly IMapper _mapper;

        //inyección de dependencias 
        public ProductsController(AdministrationCoreDbContext Context, IProductRepository Service, IMapper mapper)
        {
            _context = Context;
            _service = Service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get()
        {
            var products = await _service.GetAll();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            //var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            var product = await _service.GetProductById(id);

            if (product == null)
                return NotFound("Registro no encontrado.");

            var productDto = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                UnitPrice = (decimal)product.UnitPrice
            };

            return Ok(productDto);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductCreationDto productCreationDto)
        {
            var product = _mapper.Map<Product>(productCreationDto);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
