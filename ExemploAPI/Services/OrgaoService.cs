using ApiDocker.DTO;
using ApiDocker.Entities;
using AutoMapper;
using ApiDocker.Infra.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ApiDocker.Services
{
    public class OrgaoService : IOrgaoService
    {
        private readonly IOrgaoRepository _orgaoRepository;
        private readonly IMapper _mapper;

        public OrgaoService(IOrgaoRepository orgaoRepository, IMapper mapper)
        {
            _orgaoRepository = orgaoRepository;
            _mapper = mapper;
        }

        public List<OrgaoSemLogo> ObterTodosOrgaos()
        {
            return _mapper.Map<List<OrgaoSemLogo>>(_orgaoRepository.ObterTodos().ToList()); 
        }

        public OrgaoComLogo ObterOrgaoPorId(int id)
        {
            var orgao = _orgaoRepository.ObterPorId(id);

            if (orgao == null)
                return null;

            return _mapper.Map<OrgaoComLogo>(orgao);
        }
    }
}
