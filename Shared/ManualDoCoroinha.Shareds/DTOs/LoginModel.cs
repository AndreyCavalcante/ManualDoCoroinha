using System.ComponentModel.DataAnnotations;

namespace ManualDoCoroinha.Shared.DTOs;

public class LoginModel
{
    [Required(ErrorMessage = "Informe seu e-mail")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "informe sua senha")]
    public string? Password { get; set; }
}
