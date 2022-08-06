using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.CinemaDto;
using Alura.FilmesApi.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.FilmesApi.Services
{
    public class CinemaService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AdicionarCinema(CreateCinemaDto cinamaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinamaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> ListarCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;
                cinemas = query.ToList();
            }

            List<ReadCinemaDto> readDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);
            return readDto;
        }

        public ReadCinemaDto RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return null;

            ReadCinemaDto readCinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return readCinemaDto;
        }

        public Result DeletaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return Result.Fail("Cinema não encontrado");

            _context.Remove(cinema);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result AtualizaCinemaPorId(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return Result.Fail("Cinema não encontrado");

            //Automapper
            //sobreescrevendo / copiando os dados entre objetos
            //pegando os dados do cinemaDto e colocando em cinema
            _mapper.Map(cinemaDto, cinema);

            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
