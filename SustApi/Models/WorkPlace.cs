namespace SustApi.Models;

public class WorkPlace
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public ICollection<Employee> Employees { get; set; }
}

public static class WorkPlaceTypes
{
    public static string Department { get; set; } = "department";
    public static string Office { get; set; } = "office";
    public static string Center { get; set; } = "center";
}