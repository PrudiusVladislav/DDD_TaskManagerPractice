using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Persistence.Users;

public class UsersConfiguration: BaseEntityConfiguration<UserId, User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        builder.Property(u => u.Email).HasConversion(
            email => email.Value,
            value => Email.Create(value)!);

        builder.Property(u => u.Name).HasConversion(
            name => name.Value,
            value => UserName.Create(value));
        
        builder.HasIndex(u => u.Email).IsUnique();
    }
}