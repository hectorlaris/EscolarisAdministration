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
            CreateMap<DocumentTypeCreateDTO, DocumentType>();
            CreateMap<DocumentType, DocumentTypeDTO>();

        }
    }
}
