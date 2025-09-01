namespace onlizas.Utils.Options;

public class MinioOptions
{
    public const string SectionName = "Minio"; 

    public string Endpoint { get; set; } = string.Empty;
    public int Port { get; set; }
    public string AccessKey { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public string Bucket { get; set; } = string.Empty;
    public bool UseSsl { get; set; } = false;
}
