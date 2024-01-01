using Microsoft.EntityFrameworkCore;
using TaskManagerPractice.Persistence.Interceptors;

namespace TaskManagerPractice.Persistence;

public class TaskManagerDbContext: DbContext
{
    private readonly PublishDomainEventsInterceptor _domainEventsInterceptor;
    public DbSet<Domain.Users.User> Users { get; set; } = null!;
    public DbSet<Domain.Tasks.Task> Tasks { get; set; } = null!;
    
    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options,
        PublishDomainEventsInterceptor domainEventsInterceptor) : base(options)
    {
        _domainEventsInterceptor = domainEventsInterceptor;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_domainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerDbContext).Assembly);
    }
}