using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesas.Models
{
    [Table("Usuarios")]
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(100)]
        [Column("Nome")]
        public string Name { get; set; }

        // [Required(ErrorMessage = "Senha obrigatória!")]
        [Column("Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "CPF obrigatório")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter {1} digitos!")]
        [MinLength(11, ErrorMessage = "O CPF deve conter {1} digitos!")]
        [Column("CPF")]
        public string DocumentNumber { get; set; }
        [MaxLength(2, ErrorMessage = "DDD deve conter {1} digitos")]
        public string? DDD { get; set; }
        [StringLength(9)]
        [MaxLength(9, ErrorMessage = "O Celular deve conter {1} digitos")]
        [MinLength(9, ErrorMessage = "O Celular deve conter {1} digitos")]
        [Column("Celular")]
        public string? CelPhone { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento fornecida inválida!")]
        [Column("DataNascimento")]
        public DateTime? BirthDate { get; set; }
        [MaxLength(8, ErrorMessage = "O CEP deve conter {1} digitos")]
        [MinLength(8, ErrorMessage = "O CEP deve conter {1} digitos")]
        [Column("CEP")]
        public string? ZipCode { get; set; }
        [Column("Cidade")]
        public string? City { get; set; }
        [Column("Estado")]
        public string? State { get; set; }
        [Column("Endereco")]
        public string? Street { get; set; }
        [Column("NumeroEndereco")]
        public int? AddressNumber { get; set; }
        [Column("ComplementoEndereco")]
        public string? AddressLine { get; set; }
    }
}