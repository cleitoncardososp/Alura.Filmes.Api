using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.Filme;
using Alura.FilmesApi.Models;
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
        public FilmeController(FilmeContext context)
        {
            _context = context;
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
            Filme filme = new Filme
            {
                Titulo = filmeDto.Titulo,
                Diretor = filmeDto.Diretor,
                Genero = filmeDto.Genero,
                Duracao = filmeDto.Duracao
            };

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
                ReadFilmeDto filmeDto = new ReadFilmeDto
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    HoraDaConsulta = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")
                };
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

            filme.Titulo = filmeDto.Titulo;
            filme.Genero = filmeDto.Genero;
            filme.Diretor = filmeDto.Diretor;
            filme.Duracao = filmeDto.Duracao;
            _context.SaveChanges();
            return Ok(filme);
        }
        #endregion
    }
}
