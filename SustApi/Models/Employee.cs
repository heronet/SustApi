namespace SustApi.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string JobTitle { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string ImageUrl { get; set; }
    public WorkPlace WorkPlace { get; set; }
    public Guid WorkplaceId { get; set; }
    public string WorkplaceTitle { get; set; }
}
