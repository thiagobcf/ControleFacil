using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.contract.NaturezaDeLancamento;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Classes;
using ControleFacil.Api.Damain.Repository.Interfaces;
using ControleFacil.Api.Damain.services.Interfaces;

namespace ControleFacil.Api.Damain.services.classes
{    
    public class NaturezaDeLancamentoService : IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long>
    {
    private readonly INaturezaDeLancamentoRepository _naturezaDeLancamentoRepository;
    private readonly IMapper _mapper;
    
    public NaturezaDeLancamentoService(INaturezaDeLancamentoRepository naturezaDeLancamentoRepository, IMapper mapper)
        {
            _naturezaDeLancamentoRepository = naturezaDeLancamentoRepository;
            _mapper = mapper;
            
        }
        public async Task<NaturezaDeLancamentoResponseContract> Adicionar(NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {
            NaturezaDeLancamento naturezaDeLancamento = _mapper.Map<NaturezaDeLancamento>(entidade);

            naturezaDeLancamento.DataCadastro = DateTime.Now;
            naturezaDeLancamento.IdUsuario = idUsuario;

            naturezaDeLancamento = await _naturezaDeLancamentoRepository.Adicionar(naturezaDeLancamento);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        public async Task<NaturezaDeLancamentoResponseContract> Atualizar(long id, NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {  
            NaturezaDeLancamento naturezaDeLancamento = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            naturezaDeLancamento.Descricao = entidade.Descricao;
            naturezaDeLancamento.Observacao = entidade.Observacao;

            naturezaDeLancamento = await _naturezaDeLancamentoRepository.Atualizar(naturezaDeLancamento);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        public async Task Inativar(long id, long idUsuario)
        {
            NaturezaDeLancamento naturezaDeLancamento = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            await _naturezaDeLancamentoRepository.Deletar(naturezaDeLancamento);
        }

        public async Task<IEnumerable<NaturezaDeLancamentoResponseContract>> Obter(long idUsuario)
        {
            var naturezasDeLancamento = await _naturezaDeLancamentoRepository.ObterPeloIdUsuario(idUsuario);

            return naturezasDeLancamento.Select(n => _mapper.Map<NaturezaDeLancamentoResponseContract>(n));
        }

        public async Task<NaturezaDeLancamentoResponseContract> Obter(long id, long idUsuario)
        {
            NaturezaDeLancamento naturezaDeLancamento = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);
            
            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        private async Task<NaturezaDeLancamento> ObterPorIdVinculadoAoIdUsuario(long id, long idUsuario)
        {
            var naturezaDeLancamento = await _naturezaDeLancamentoRepository.obter(id);

            if (naturezaDeLancamento is null || naturezaDeLancamento.IdUsuario != idUsuario)
            {
                throw new Exception($"Não foi encontrada nenhuma natureza de lançamento pelo id {id}");
            }

            return naturezaDeLancamento;
        }
    }
}