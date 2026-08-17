namespace ManualDoCoroinha.Shared.DTOs.UserCertificates;

public class UserCertificateDto
{
    public Guid UserCertificateId { get; set; }
    public Guid UserId { get; set; }
    public Guid CertificateId { get; set; }
    public DateTime GeneratedAt { get; set; }
}
