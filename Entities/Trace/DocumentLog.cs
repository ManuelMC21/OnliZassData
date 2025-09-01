using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Trace;

public class DocumentLog:BaseEntity
{
    public int DocumentId { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;


    public string FileName { get; set; }
    public string Content { get; set; }
    public bool IsApproved { get; set; } = false;
    public bool IsMandatory { get; set; } = true;
    public DateTime? ValidationDate { get; set; }
    public string? RejectionReason { get; set; }
    public int SupplierId { get; set; }
    public string? ParentSupplierName { get; set; }

    public DocumentLog() { }
}
