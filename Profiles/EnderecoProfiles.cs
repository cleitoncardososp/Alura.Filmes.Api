using Alura.FilmesApi.Data.Dtos.EnderecoDto;
using Alura.FilmesApi.Models;
using AutoMapper;

namespace Alura.FilmesApi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
