namespace onlizas.Utils.Options;

public sealed class RabbitMqOptions
{
    public required string Host { get; set; }
    public required int Port { get; set; }
    public required string VirtualHost { get; set; }
    public required string User { get; set; }
    public required string Pass { get; set; }
}