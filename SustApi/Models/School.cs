namespace SustApi.Models;

public class School
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public ICollection<WorkPlace> Departments { get; set; }
}
