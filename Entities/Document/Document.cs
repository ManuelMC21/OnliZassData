using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class Document : BaseEntity
{
    public required string FileName { get; set; }
    public required string Content { get; set; }
    public bool IsApproved { get; set; } = false;
    public bool IsMandatory { get; set; } = true;
    public DateTime? ValidationDate { get; set; }
    public string? RejectionReason { get; set; }

    // Documentos “aprobados” del proceso
    public int? ApprovalProcessId { get; set; }
    public ApprovalProcess? ApprovalProcess { get; set; }

    // Documentos relacionados con la “extensión” del proceso
    public int? ExtensionApprovalProcessId { get; set; }
    public ApprovalProcess? ExtensionApprovalProcess { get; set; }
}