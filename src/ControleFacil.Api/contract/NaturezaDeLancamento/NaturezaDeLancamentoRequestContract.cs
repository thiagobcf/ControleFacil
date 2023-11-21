using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.contract.NaturezaDeLancamento
{
    public class NaturezaDeLancamentoRequestContract
    {
        public string Descricao { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;

    }
}