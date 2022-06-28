using Alura.FilmesApi.Data.Dtos.GerenteDto;
using Alura.FilmesApi.Models;
using AutoMapper;

namespace Alura.FilmesApi.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>();
            CreateMap<UpdateGerenteDto, Gerente>();
        }
    }
}
