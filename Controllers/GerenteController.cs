using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.GerenteDto;
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
    public class GerenteController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GerenteController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId([FromRoute] int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
                return NotFound();

            ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

            return Ok(gerenteDto);
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            List<Gerente> listaGerentes = _context.Gerentes.ToList();
            List<ReadGerenteDto> listaGerentesDto = new List<ReadGerenteDto>();

            foreach (var item in listaGerentes)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(item);
                listaGerentesDto.Add(gerenteDto);
            }
            return Ok(listaGerentesDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGerente([FromRoute] int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Gerente gerenteToUpdate = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerenteToUpdate == null)
                return NotFound();

            //sobreescrevendo / copiando os dados entre objetos
            //pegando os dados do filmeDto e colocando em filme
            _mapper.Map(gerenteDto, gerenteToUpdate);

            return Ok(gerenteToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerentePorId([FromRoute]int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id); ;
            if (gerente == null)
                return NotFound();

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
