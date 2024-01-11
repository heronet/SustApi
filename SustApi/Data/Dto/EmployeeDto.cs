using System.ComponentModel.DataAnnotations;

namespace SustApi.Data.Dto;

public class EmployeeDto
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string JobTitle { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Website { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public string WorkplaceTitle { get; set; }
}
