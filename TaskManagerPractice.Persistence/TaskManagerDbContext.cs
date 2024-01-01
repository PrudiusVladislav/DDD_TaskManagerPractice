using Microsoft.EntityFrameworkCore;

namespace TaskManagerPractice.Persistence;

public class TaskManagerDbContext: DbContext
{
    public DbSet<Domain.Users.User> Users { get; set; } = null!;
    public DbSet<Domain.Tasks.Task> Tasks { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerDbContext).Assembly);
    }
}