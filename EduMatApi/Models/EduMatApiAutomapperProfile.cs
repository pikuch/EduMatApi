using AutoMapper;
using EduMatApi.Models.DTOs;
using EduMatApi.Models.Entities;

namespace EduMatApi.Models
{
    public class EduMatApiAutomapperProfile : Profile
    {
        public EduMatApiAutomapperProfile()
        {
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<Author, AuthorReadDto>();

            CreateMap<MaterialCreateDto, Material>();
            CreateMap<Material, MaterialReadDto>();

            CreateMap<MaterialTypeCreateDto, MaterialType>();
            CreateMap<MaterialType, MaterialTypeReadDto>();

            CreateMap<ReviewCreateDto, Review>();
            CreateMap<Review, ReviewReadDto>();
        }
    }
}
