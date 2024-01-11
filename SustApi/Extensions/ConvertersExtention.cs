using SustApi.Data.Dto;
using SustApi.Models;

namespace SustApi.Extensions;

public static class ConvertersExtention
{
    public static EmployeeDto ToEmployeeDto(this Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            JobTitle = employee.JobTitle,
            Phone = employee.Phone,
            Email = employee.Email,
            Website = employee.Website,
            ImageUrl = employee.ImageUrl,
            WorkplaceTitle = employee.WorkplaceTitle
        };
    }
    public static Employee ToEmployee(this EmployeeDto employee)
    {
        return new Employee
        {
            Name = employee.Name.Trim(),
            JobTitle = employee.JobTitle.Trim(),
            Phone = employee.Phone.Trim(),
            Email = employee.Email.Trim(),
            Website = employee.Website.Trim(),
            ImageUrl = employee.ImageUrl.Trim(),
            WorkplaceTitle = employee.WorkplaceTitle.Trim()
        };
    }

    public static WorkPlaceDto ToWorkplaceDto(this WorkPlace workplace)
    {
        return new WorkPlaceDto
        {
            Title = workplace.Title,
            Type = workplace.Type
        };
    }

    public static WorkPlace ToWorkplace(this WorkPlaceDto workplace)
    {
        return new WorkPlace
        {
            Title = workplace.Title,
            Type = workplace.Type
        };
    }
}
