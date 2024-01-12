using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SustApi.Data;
using SustApi.Data.Dto;
using SustApi.Extensions;
using SustApi.Models;

namespace SustApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    public SustDbContext DbContext { get; }
    public EmployeesController(SustDbContext dbContext)
    {
        DbContext = dbContext;
    }

    [HttpGet("{workplaceType}")]
    public async Task<ActionResult> GetEmployeesByWorkplaceName([FromRoute] string workplaceType, [FromQuery] string title)
    {
        var workplace = await DbContext.WorkPlaces
            .Where(w => w.Type == workplaceType.Trim() && w.Title == title.Trim())
            .Include(w => w.Employees)
            .FirstOrDefaultAsync();

        if (workplace is null)
            return BadRequest("Workplace does not exist");

        var employees = workplace.Employees.Select(e => e.ToEmployeeDto());

        return Ok(employees);
    }
    [HttpGet("workplaces")]
    public async Task<ActionResult> GetWorkplaces(string workplaceType)
    {
        var workplace = await DbContext.WorkPlaces
            .Where(w => w.Type == workplaceType.Trim())
            .FirstOrDefaultAsync();

        if (workplace is null)
            return BadRequest("Workplace does not exist");

        return Ok(workplace);
    }

    [HttpPost]
    public async Task<ActionResult> AddEmployee(EmployeeDto employeeDto)
    {
        var workplace = await DbContext.WorkPlaces
            .Include(w => w.Employees)
            .FirstOrDefaultAsync(w => w.Title.ToLower() == employeeDto.WorkplaceTitle.ToLower().Trim());

        if (workplace is null)
            return BadRequest("Workplace does not exist");

        // If workplace and jobtitle are the same, it's a duplicate
        // Because it is not possible to be hold same position at the same place simultaneously 
        var employee = workplace.Employees.FirstOrDefault(
            e => (e.WorkplaceTitle.ToLower() == employeeDto.WorkplaceTitle.ToLower().Trim()) &&
                (e.Email.ToLower() == employeeDto.Email.ToLower().Trim()) &&
                (e.JobTitle.ToLower() == employeeDto.JobTitle.ToLower().Trim())
        );
        if (employee is not null)
            return BadRequest("Employee already exists");


        employee = employeeDto.ToEmployee();

        workplace.Employees.Add(employee);

        var result = await DbContext.SaveChangesAsync();

        if (result > 0)
        {
            return RedirectToAction(
                nameof(GetEmployeesByWorkplaceName),
                new { workplaceType = workplace.Type, title = workplace.Title }
            );
        }

        return BadRequest("An error occured");
    }

    [HttpPost("workplaces")]
    public async Task<ActionResult> AddWorkplace(WorkPlaceDto workplaceDto)
    {
        if (workplaceDto.Type.ToLower().Trim() != WorkPlaceTypes.Office &&
            workplaceDto.Type.ToLower().Trim() != WorkPlaceTypes.Center &&
            workplaceDto.Type.ToLower().Trim() != WorkPlaceTypes.Department)
        {
            return BadRequest("Invalid Workspace");
        }

        var workplace = await DbContext.WorkPlaces
            .FirstOrDefaultAsync(w => w.Title.ToLower() == workplaceDto.Title.ToLower().Trim());

        if (workplace is not null)
            return BadRequest("Workplace already exists");

        workplace = workplaceDto.ToWorkplace();

        DbContext.WorkPlaces.Add(workplace);

        var result = await DbContext.SaveChangesAsync();

        if (result > 0)
        {
            return RedirectToAction(
                nameof(GetEmployeesByWorkplaceName),
                new { workplaceType = workplace.Type, workplaceTitle = workplace.Title }
            );
        }

        return BadRequest("An error occured");
    }
}
