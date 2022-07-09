using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.CinemaDto;
using Alura.FilmesApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.FilmesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CinemaController : ControllerBase
    {
        public FilmeContext _context;
        public IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region [Métodos HTTP]
        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinamaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinamaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult ListaCinemas([FromQuery] string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return NotFound();
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
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId([FromRoute] int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return NotFound();

            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinemaPorId([FromRoute] int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return NotFound();

            _context.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinemaPorId([FromRoute] int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return NotFound();

            //Automapper
            //sobreescrevendo / copiando os dados entre objetos
            //pegando os dados do cinemaDto e colocando em cinema
            _mapper.Map(cinemaDto, cinema);

            _context.SaveChanges();
            return Ok(cinema);
        }
        #endregion

    }
}
