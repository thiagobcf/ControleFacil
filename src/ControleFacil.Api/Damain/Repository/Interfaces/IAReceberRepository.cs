using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;

namespace ControleFacil.Api.Damain.Repository.Interfaces
{
    public interface IAReceberRepository : IRepository<Areceber, long>
    {
      Task<IEnumerable<Areceber>> ObterPeloIdUsuario(long idUsuario);
    }
}