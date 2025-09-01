namespace onlizas.Entities;

public class ApprovalProcessApprovedCategory
{
    public int ApprovalProcessId { get; set; }
    public ApprovalProcess ApprovalProcess { get; set; } = null!;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}