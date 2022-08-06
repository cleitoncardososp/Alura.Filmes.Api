using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.SessaoDto;
using Alura.FilmesApi.Models;
using Alura.FilmesApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.FilmesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }


        #region [Métodos HTTP]
        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.AdicionaSessao(sessaoDto);

            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readSessaoDto.Id }, readSessaoDto );
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId([FromRoute] int id)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.RecuperaSessaoPorId(id);

            return Ok(readSessaoDto);            
        }

        [HttpGet]
        public IActionResult RecuperaSessao()
        {
            List<ReadSessaoDto> listaReadSessaoDtos =  _sessaoService.RecuperaSessao();

            if (listaReadSessaoDtos == null)
                return NoContent();

            return Ok(listaReadSessaoDtos);
        }

        //TODO: Outros métodos

        //[HttpPut]

        //[HttpDelete]
        #endregion
    }
}
