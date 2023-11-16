using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.contract.Usuario;
using ControleFacil.Api.Damain.Repository.Interfaces;
using ControleFacil.Api.Damain.services.Interfaces;

namespace ControleFacil.Api.Damain.services.classes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<UsuarioResponseContract> Adicionar(UsuarioRequestContract entiade, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponseContract> Atualizar(long id, UsuarioRequestContract entiade, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequest)
        {
            throw new NotImplementedException();
        }

        public Task Inativar(long id, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioResponseContract>> Obter(long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponseContract> Obter(long id, long idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}