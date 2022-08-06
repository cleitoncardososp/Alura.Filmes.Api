using Alura.FilmesApi.Data.Dtos.FilmeDto;
using Alura.FilmesApi.Models;
using Alura.FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.FilmesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        #region [Métodos HTTP]
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionaFilme(filmeDto);

            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult ListaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> listaReadFilmeDto = _filmeService.RecuperaFilme(classificacaoEtaria);

            if (listaReadFilmeDto != null) return Ok(listaReadFilmeDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId([FromRoute] int id)
        {
            ReadFilmeDto filmeDto = _filmeService.RecuperaFilmePorId(id);

            if (filmeDto != null) return Ok(filmeDto);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilmePorId([FromRoute] int id)
        {
            Result resultado = _filmeService.DeletaFilmePorId(id);

            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilmePorId([FromRoute] int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = _filmeService.AtualizarFilmePorId(id, filmeDto);

            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }
        #endregion
    }
}
