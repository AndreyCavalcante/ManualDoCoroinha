using ManualDoCoroinha.Models.Certificates;
using ManualDoCoroinha.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.UserCertificates;

public class UserCertificate
{
    [Key]
    public Guid UserCertificateId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [JsonIgnore]
    public User User { get; set; }

    [Required]
    public Guid CertificateId { get; set; }

    [JsonIgnore]
    public Certificate Certificate { get; set; }

    [Required]
    public DateTime GeneratedAt { get; set; }
}
