using System.ComponentModel.DataAnnotations;

namespace SustApi.Data.Dto;

public class WorkPlaceDto
{
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Type { get; set; }
}
