using Microsoft.EntityFrameworkCore;
using SustApi.Models;

namespace SustApi.Data;

public class SustDbContext : DbContext
{
    public SustDbContext(DbContextOptions options) : base(options) { }
    public DbSet<WorkPlace> WorkPlaces { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
