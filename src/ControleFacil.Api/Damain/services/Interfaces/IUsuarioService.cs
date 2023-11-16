using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.contract.Usuario;

namespace ControleFacil.Api.Damain.services.Interfaces
{
    public interface IUsuarioService : IService<UsuarioRequestContract, UsuarioResponseContract,long>
    {
        Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequest);
    }
}