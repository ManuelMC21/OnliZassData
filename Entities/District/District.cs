using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class District : BaseEntity
{
    public required string Name { get; set; }
    public string[] ZipCodes { get; set; } = [];

    public int StateId { get; set; }
    public State? State { get; set; }
    public bool DifficultAccessArea { get; set; } = false;
}