using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.FilmeDto;
using Alura.FilmesApi.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.FilmesApi.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            //Mapper: convertendo o filmeDto do tipo CreateFilmeDto em um Filme
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilme(int? classificacaoEtaria)
        {
            List<Filme> filmes = new List<Filme>();
            List<ReadFilmeDto> readFilmeDtos = new List<ReadFilmeDto>();

            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                readFilmeDtos = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readFilmeDtos;
            }
            else
            {
                return null;
            }
        }

        public ReadFilmeDto RecuperaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return filmeDto;
            }
            return null;
        }

        public Result DeletaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return Result.Fail("Filme não encontrado");

            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok(); 
        }

        public Result AtualizarFilmePorId(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return Result.Fail("Filme não encontrado");

            //sobreescrevendo / copiando os dados entre objetos
            //pegando os dados do filmeDto e colocando em filme
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
