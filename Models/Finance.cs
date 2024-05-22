using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleDespesas.Models
{
    [Table("Financeiro")]
    public class Finance
    {
        public int FinanceId { get; set; }
        [Required(ErrorMessage = "Informe um titulo!")]
        [Column("Titulo")]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Informe um valor!")]
        [Column("Valor")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "Informe o tipo do lançamento!")]
        [Column("Tipo")]
        [MaxLength(1, ErrorMessage = "Valor inválido!")]
        [MinLength(1, ErrorMessage = "Valor inválido!")]
        public string Type { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        [Column("UsuarioId")]
        public User? User { get; set; }
    }
}