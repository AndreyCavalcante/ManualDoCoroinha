using System.ComponentModel.DataAnnotations;

namespace ManualDoCoroinha.Shared.DTOs;

public class RegisterModel
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Username é obrigatório")]
    public string? Username { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email é obrigatório")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Data de nascimento é obrigatória")]
    public DateOnly Birthday { get; set; }

}
