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
    [Route("titulos-areceber")]
    public class AreceberController : BaseController
    {
        private readonly IService<AreceberRequestContract, AreceberResponseContract, long> _areceberService;

        private long _idUsuario;

        public AreceberController(
            IService<AreceberRequestContract, AreceberResponseContract, long> areceberService)
        {
            _areceberService = areceberService;
            
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(AreceberRequestContract contrato)
        {
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Created("", await _areceberService.Adicionar(contrato, _idUsuario));
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
                return Ok(await _areceberService.Obter(_idUsuario));
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
                return Ok(await _areceberService.Obter(id, _idUsuario));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(long id, AreceberRequestContract contrato)
        {
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Ok(await _areceberService.Atualizar(id, contrato, _idUsuario));
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
                await _areceberService.Inativar(id, _idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                
                return Problem(ex.Message);
            }
        }
    }
}
