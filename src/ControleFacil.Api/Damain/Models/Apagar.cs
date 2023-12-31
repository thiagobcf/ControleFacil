using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.contract.Usuario;

namespace ControleFacil.Api.Damain.Models
{
    public class Apagar : Titulo
    {
        [Required(ErrorMessage = "O preenchimento do campo ValorPago é obrigatório")]
        public double ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}