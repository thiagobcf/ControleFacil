using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using ControleFacil.Api.contract.NaturezaDeLancamento;
using ControleFacil.Api.contract.Usuario;
using ControleFacil.Api.Damain.services.classes;
using ControleFacil.Api.Damain.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    [ApiController]
    [Route("titulos-apagar")]
    public class ApagarController : BaseController
    {
        private readonly IService<ApagarRequestContract, ApagarResponseContract, long> _apagarService;

        private long _idUsuario;

        public ApagarController(
            IService<ApagarRequestContract, ApagarResponseContract, long> apagarService)
        {
            _apagarService = apagarService;
            
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(ApagarRequestContract contrato)
        {
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Created("", await _apagarService.Adicionar(contrato, _idUsuario));
            }
            catch (Exception ex)
            {
                
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Obter()
        {
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Ok(await _apagarService.Obter(_idUsuario));
            }
            catch (Exception ex)
            {
                
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Obter(long id)
        {
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Ok(await _apagarService.Obter(id, _idUsuario));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(long id, ApagarRequestContract contrato)
        {
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Ok(await _apagarService.Atualizar(id, contrato, _idUsuario));
            }
            catch (Exception ex)
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Deletar(long id)
        {
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                await _apagarService.Inativar(id, _idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                
                return Problem(ex.Message);
            }
        }
    }
}
