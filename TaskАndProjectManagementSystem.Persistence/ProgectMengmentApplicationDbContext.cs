using Microsoft.EntityFrameworkCore;
using TaskАndProjectManagementSystem.Domain;

namespace TaskАndProjectManagementSystem.Persistence;
public class ProgectMengmentApplicationDbContext : DbContext
{
    public ProgectMengmentApplicationDbContext(DbContextOptions<ProgectMengmentApplicationDbContext> options) : base(options)
    {
                
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProgectMengmentApplicationDbContext).Assembly);
    }
    DbSet<User> Users { get; set; }
    DbSet<Project> Projects { get; set; }
    DbSet<TaskProd> Tasks { get; set; }
}
