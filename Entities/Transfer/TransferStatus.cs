using System.Text.Json.Serialization;

namespace onlizas.Entities.Transfer
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransferStatus
    {
        Pending = 0,
        Approved = 1,
        InTransit = 2,
        Completed = 3,
        Cancelled = 4
    }
}