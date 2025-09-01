using System.Text.Json.Serialization;

namespace onlizas.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProcessState
{
    Pending = 0,
    WaitingLogin = 1,
    Approved = 2,
    Rejected = 3,
    WaitingExtension = 4,
    Expired = 5,
}