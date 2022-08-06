using Alura.FilmesApi.Data;
using Alura.FilmesApi.Data.Dtos.SessaoDto;
using Alura.FilmesApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.FilmesApi.Services
{
    public class SessaoService
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public SessaoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
                return null;

            ReadSessaoDto readSessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return readSessaoDto;
        }

        public List<ReadSessaoDto> RecuperaSessao()
        {
            List<Sessao> listaSessao = _context.Sessoes.ToList();

            if (listaSessao == null)
                return null;

            return _mapper.Map<List<ReadSessaoDto>>(listaSessao);
        }
    }
}
