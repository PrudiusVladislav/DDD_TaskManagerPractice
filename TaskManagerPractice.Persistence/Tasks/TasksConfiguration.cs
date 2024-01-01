using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;
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
        
        builder.Property(t => t.UserId).HasConversion(
            id => id.Value,
            value => TypedIdBase.Create<UserId>(value));
    }
}