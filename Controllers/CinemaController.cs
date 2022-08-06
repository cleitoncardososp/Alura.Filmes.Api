using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.CinemaDto;
using Alura.FilmesApi.Models;
using Alura.FilmesApi.Services;
using AutoMapper;
using FluentResults;
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
        public CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        #region [Métodos HTTP]
        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinamaDto)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.AdicionarCinema(cinamaDto);

            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = readCinemaDto.Id }, readCinemaDto);
        }

        [HttpGet]
        public IActionResult ListaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> listaReadCinemaDto = _cinemaService.ListarCinemas(nomeDoFilme);

            if (listaReadCinemaDto == null)
                return NoContent();

            return Ok(listaReadCinemaDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId([FromRoute] int id)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.RecuperaCinemaPorId(id);

            if (readCinemaDto == null)
                return NotFound();

            return Ok(readCinemaDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinemaPorId([FromRoute] int id)
        {
            Result resultado = _cinemaService.DeletaCinemaPorId(id);

            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinemaPorId([FromRoute] int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizaCinemaPorId(id, cinemaDto);

            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }
        #endregion

    }
}
