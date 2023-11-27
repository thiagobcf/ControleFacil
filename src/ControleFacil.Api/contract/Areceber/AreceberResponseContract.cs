using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.contract.NaturezaDeLancamento
{
    public class AreceberResponseContract : AreceberRequestContract
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataInatividade { get; set; }

    }
}