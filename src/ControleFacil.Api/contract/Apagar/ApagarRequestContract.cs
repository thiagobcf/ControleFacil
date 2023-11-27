using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.contract.NaturezaDeLancamento
{
    public class ApagarRequestContract : TituloRequestContract
    { 
        public double ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}