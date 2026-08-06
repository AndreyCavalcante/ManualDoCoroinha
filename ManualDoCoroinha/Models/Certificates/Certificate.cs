using ManualDoCoroinha.Models.UserCertificates;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.Certificates;

public class Certificate
{
    [Key]
    public Guid CertificateId { get; set; }

    [Required]
    [StringLength(500)]
    public string Title { get; set; }

    [Required]
    public string Code { get; set; }

    [JsonIgnore]
    public ICollection<UserCertificate> Users { get; set; } = new List<UserCertificate>();
}
