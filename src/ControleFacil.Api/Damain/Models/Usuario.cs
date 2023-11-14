using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Damain.Models
{
    public class Usuario
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo de E-mail é obrigatório")]
        public string Email { get; set; } = string.Empty;  // Nao pode ser nula

        [Required(ErrorMessage = "O preenchimento do campo de Senha é obrigatório")]
        public string Senha { get; set; } = string.Empty; 

        [Required]
        public DateTime DataCadastro{ get; set; }

        public DateTime? DataInatividade { get; set; }      // Nullable
        
    }
}