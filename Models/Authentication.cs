using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesas.Models
{
    [NotMapped]
    public class Authentication
    {
        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha obrigatória")]
        public string Password { get; set; }
    }
}