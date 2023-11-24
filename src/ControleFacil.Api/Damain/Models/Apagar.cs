using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.contract.Usuario;

namespace ControleFacil.Api.Damain.Models
{
    public class Apagar
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdUsuario { get; set; }
        public  Usuario Usuario { get; set; }

        [Required]
        public long IdNaturezaDeLancamento { get; set; }
        public  NaturezaDeLancamento NaturezaDeLancamento { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo de Descrição é obrigatório")]
        public string Descricao { get; set; } = string.Empty;  // Nao pode ser nula


        [Required(ErrorMessage = "O preenchimento do campo ValorOriginal é obrigatório")]
        public double ValorOriginal { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo ValorPago é obrigatório")]
        public double ValorPago { get; set; }
        
        public string? Observacao { get; set; } = string.Empty; 

        [Required]
        public DateTime DataCadastro{ get; set; }

        [Required(ErrorMessage = "O preenchimento do campo DataVencimento é obrigatório")]
        public DateTime DataVencimento{ get; set; }

        public DateTime? DataInatividade { get; set; }      // Nullable
        
        public DateTime? DataReferencia { get; set; }

        public DateTime? DataPagamento { get; set; }
    }
}