using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using Task = TaskManagerPractice.Domain.Tasks.Task;

namespace TaskManagerPractice.Persistence.Tasks;

public class TasksConfiguration: BaseEntityConfiguration<TaskId, Task>
{
    public override void Configure(EntityTypeBuilder<Task> builder)
    {
        base.Configure(builder);
        
        builder.Property(t => t.State)
            .HasConversion(
                state => state.ToString(),
                value => Enum.Parse<TaskState>(value));

        builder.OwnsOne(t => t.LifeRange);
    }
}