using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class Address : BaseEntity
{
    public required string Name { get; set; }
    public required string? Annotations { get; set; }
    public required string MainStreet { get; set; }
    public required string Number { get; set; }
    public required string? OtherStreets { get; set; }
    public required string? City { get; set; }
    public required string? State { get; set; }
    public required string? Zipcode { get; set; }

    public required int CountryId { get; set; }
    public Country? Country { get; set; }

    public required int UserId { get; set; }
    public User? User { get; set; }

    public required decimal? Latitude { get; set; }
    public required decimal? Longitude { get; set; }

    public override string ToString()
    {
        return $"{Name} - {MainStreet} {Number}, {City}, {State}, {Country?.Name}";
    }
}