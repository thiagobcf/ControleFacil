using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.contract.Usuario;

namespace ControleFacil.Api.Damain.Models
{
    public class Areceber: Titulo
    {
        [Required(ErrorMessage = "O preenchimento do campo ValorRecebido é obrigatório")]
        public double ValorRecebido { get; set; }
        public DateTime? DataRecebimento { get; set; }
    }
}