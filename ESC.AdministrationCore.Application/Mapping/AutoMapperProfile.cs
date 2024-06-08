using AutoMapper;
using EESC.AdministrationCore.Application.DTOs;
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

        }
    }
}
