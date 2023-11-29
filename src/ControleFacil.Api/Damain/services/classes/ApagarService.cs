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
using ControleFacil.Api.Exceptions;

namespace ControleFacil.Api.Damain.services.classes
{    
    public class ApagarService : IService<ApagarRequestContract, ApagarResponseContract, long>
    {
        private readonly IApagarRepository _apagarRepository;
        private readonly IMapper _mapper;
    
        public ApagarService(IApagarRepository apagarRepository, IMapper mapper)
        {
            _apagarRepository = apagarRepository;
            _mapper = mapper;
            
        }
        public async Task<ApagarResponseContract> Adicionar(ApagarRequestContract entidade, long idUsuario)
        {
            Validar(entidade);            
            Apagar Apagar = _mapper.Map<Apagar>(entidade);

            Apagar.DataCadastro = DateTime.Now;
            Apagar.IdUsuario = idUsuario;

            Apagar = await _apagarRepository.Adicionar(Apagar);

            return _mapper.Map<ApagarResponseContract>(Apagar);
        }

        public async Task<ApagarResponseContract> Atualizar(long id, ApagarRequestContract entidade, long idUsuario)
        {
            Validar(entidade); 
            Apagar apagar = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            var contrato = _mapper.Map<Apagar>(entidade);
            contrato.IdUsuario = apagar.IdUsuario;
            contrato.Id = apagar.Id;
            contrato.DataCadastro = apagar.DataCadastro;

            // apagar.Descricao = entidade.Descricao;
            // apagar.Observacao = entidade.Observacao;
            // apagar.ValorOriginal = entidade.ValorOriginal;
            // apagar.ValorPago = entidade.ValorPago;
            // apagar.DataPagamento = entidade.DataPagamento;
            // apagar.DataReferencia = entidade.DataReferencia;
            // apagar.DataVencimento = entidade.DataVencimento;
            // apagar.IdNaturezaDeLancamento = entidade.IdNaturezaDeLancamento;
            
            contrato = await _apagarRepository.Atualizar(contrato);

            return _mapper.Map<ApagarResponseContract>(contrato);
        }

        public async Task Inativar(long id, long idUsuario)
        {
            Apagar apagar = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            await _apagarRepository.Deletar(apagar);
        }

        public async Task<IEnumerable<ApagarResponseContract>> Obter(long idUsuario)
        {
            var titulosApagar = await _apagarRepository.ObterPeloIdUsuario(idUsuario);

            return titulosApagar.Select(titulo => _mapper.Map<ApagarResponseContract>(titulo));
        }

        public async Task<ApagarResponseContract> Obter(long id, long idUsuario)
        {
            Apagar apagar = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);
            
            return _mapper.Map<ApagarResponseContract>(apagar);
        }

        private async Task<Apagar> ObterPorIdVinculadoAoIdUsuario(long id, long idUsuario)
        {
            var apagar = await _apagarRepository.obter(id);

            if (apagar is null || apagar.IdUsuario != idUsuario)
            {
                throw new NotFoundException($"Não foi encontrada nenhum titulo apagar pelo id {id}");
            }

            return apagar;
        }

        private void Validar(ApagarRequestContract entidade)
        {
            // incluir validações
            if (entidade.ValorOriginal < 0 || entidade.ValorPago < 0)
            {
                throw new BadRequestException("os campos ValorOriginal e ValorRecebimento não podem ser negativos.");
            }
        }
    }
}