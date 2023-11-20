using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.contract.Usuario;

namespace ControleFacil.Api.Damain.Models
{
    public class NaturezaDeLancamento
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdUsuario { get; set; }
        public required Usuario Usuario { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo de Descrição é obrigatório")]
        public string Descricao { get; set; } = string.Empty;  // Nao pode ser nula
        
        public string? Observacao { get; set; } = string.Empty; 

        [Required]
        public DateTime DataCadastro{ get; set; }

        public DateTime? DataInatividade { get; set; }      // Nullable
        
        
    }
}