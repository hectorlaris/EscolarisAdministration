using AutoMapper;
using ESC.AdministrationCore.Application.DTOs;
using ESC.AdministrationCore.Entities.DbSet; //Domain.Entities;

namespace ESC.AdministrationCore.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Definir mapeos 
            CreateMap<CitizenCreateDTO, Citizen>();
            CreateMap<Citizen, CitizenDTO>();

            CreateMap<DocumentTypeCreateDTO, DocumentType>();
            CreateMap<DocumentType, DocumentTypeDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();   
            
            CreateMap<ProductCreationDto, Product>();
            CreateMap<Product, ProductCreationDto>();
            
        }
    }
}
