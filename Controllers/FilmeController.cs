﻿using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.Filme;
using Alura.FilmesApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.FilmesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region [Métodos Auxiliares]
        public Filme ProcuraFilmePeloId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            return filme;
        }
        #endregion

        #region [Métodos HTTP]
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            //Mapper: convertendo o filmeDto do tipo CreateFilmeDto em um Filme
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult ListaFilmes()
        {
            List<Filme> filmes = _context.Filmes.ToList();
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId([FromRoute] int id)
        {
            Filme filme = ProcuraFilmePeloId(id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                filmeDto.HoraDaConsulta = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilmePorId([FromRoute] int id)
        {
            Filme filme = ProcuraFilmePeloId(id);
            if (filme == null)
                return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilmePorId([FromRoute] int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = ProcuraFilmePeloId(id);
            if (filme == null)
                return NotFound();

            //sobreescrevendo / copiando os dados entre objetos
            //pegando os dados do filmeDto e colocando em filme
            _mapper.Map(filmeDto, filme);

            _context.SaveChanges();
            return Ok(filme);
        }
        #endregion
    }
}
