using LoginSystem.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LoginSystem.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(30, ErrorMessage = "O nome não pode exceder 30 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone fornecido não é válido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
