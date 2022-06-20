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
        public static List<Filme> filmes = new List<Filme>();
        public static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult ListaFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId([FromRoute] int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
                return Ok(filme);

            return NotFound();
        }
    }
}
