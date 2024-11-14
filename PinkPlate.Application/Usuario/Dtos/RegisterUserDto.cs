using System.ComponentModel.DataAnnotations;

namespace PinkPlate.Application.Usuarios.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
