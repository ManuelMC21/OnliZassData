namespace onlizas.Entities.QueryResults;

public class DepartmentSortedResult
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string? description { get; set; }
    public string? image { get; set; }
    public bool is_active { get; set; }
    public int categories_count { get; set; }
    public long total_count { get; set; } 
}