using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleDespesas.Models
{
    [Table("Carteira")]
    public class Wallet
    {
        [Column("CarteiraId")]
        public int WalletId { get; set; }
        [Column("UsuarioId")]
        public int UserId { get; set; }
        [Column("Total", TypeName = "decimal(10,2)")]
        public decimal Value { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}