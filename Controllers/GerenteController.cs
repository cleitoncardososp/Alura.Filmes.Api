using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.GerenteDto;
using Alura.FilmesApi.Models;
using Alura.FilmesApi.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.FilmesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.AdicionarGerente(gerenteDto);

            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readGerenteDto.Id }, readGerenteDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId([FromRoute] int id)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.RecuperaGerentePorId(id);

            if (readGerenteDto == null)
                return NotFound();

            return Ok(readGerenteDto);
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            List<ReadGerenteDto> listaGerentesDto = _gerenteService.RecuperaGerentes();

            if (listaGerentesDto == null)
                return NoContent();

            return Ok(listaGerentesDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGerente([FromRoute] int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Result resultado = _gerenteService.AtualizarGerente(id, gerenteDto);

            if (resultado.IsFailed)
                return NotFound();

            return NoContent();            
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerentePorId([FromRoute]int id)
        {
            Result resultado = _gerenteService.DeletarGerentePorId(id);

            if (resultado.IsFailed)
                return NotFound();
           
            return NoContent();
        }
    }
}
