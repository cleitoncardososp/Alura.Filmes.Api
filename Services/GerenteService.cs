using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.GerenteDto;
using Alura.FilmesApi.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.FilmesApi.Services
{
    public class GerenteService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GerenteService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionarGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
                return null;

            ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

            return gerenteDto;
        }

        public List<ReadGerenteDto> RecuperaGerentes()
        {
            List<Gerente> listaGerentes = _context.Gerentes.ToList();
            if (listaGerentes == null)
                return null;

            return _mapper.Map<List<ReadGerenteDto>>(listaGerentes);
        }

        public Result AtualizarGerente(int id, UpdateGerenteDto gerenteDto)
        {
            Gerente gerenteToUpdate = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerenteToUpdate == null)
                return Result.Fail("Gerente não encontrado");

            //sobreescrevendo / copiando os dados entre objetos
            //pegando os dados do filmeDto e colocando em filme
            _mapper.Map(gerenteDto, gerenteToUpdate);

            return Result.Ok();
        }

        internal Result DeletarGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id); ;
            if (gerente == null)
                return Result.Fail("Gerente não encontrado");

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
