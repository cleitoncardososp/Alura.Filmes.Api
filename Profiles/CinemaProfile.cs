using Alura.FilmesApi.Data.Dtos.CinemaDto;
using Alura.FilmesApi.Models;
using AutoMapper;

namespace Alura.FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
