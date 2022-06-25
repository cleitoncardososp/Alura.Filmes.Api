using Alura.FilmesApi.Data.Dtos.FilmeDto;
using Alura.FilmesApi.Models;
using AutoMapper;

namespace Alura.FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
