
using Microsoft.EntityFrameworkCore;
using person_management_system.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PersonModel> Persons { get; set; } = null!;
}