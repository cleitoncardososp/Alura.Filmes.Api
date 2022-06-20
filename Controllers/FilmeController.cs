using Alura.FilmesApi.Data;
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
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
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
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
                return Ok(filme);

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
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilmePorId([FromRoute] int id, [FromBody] Filme novoFilme)
        {
            Filme filme = ProcuraFilmePeloId(id);
            if (filme == null)
                return NotFound();

            filme.Titulo = novoFilme.Titulo;
            filme.Genero = novoFilme.Genero;
            filme.Duracao = novoFilme.Duracao;
            _context.SaveChanges();
            return Ok(filme);
        }
        #endregion
    }
}
