using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Users.Events;
using TaskManagerPractice.Domain.Users.Exceptions;
using Task = TaskManagerPractice.Domain.Tasks.Task;
namespace TaskManagerPractice.Domain.Users;

public class User: Entity<UserId>
{
    public UserName Name { get; private set; }
    public Email Email { get; private set; }
    
    private User(UserId id, UserName name, Email email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public static User Create(UserId id, UserName name, Email email)
    {
        var user = new User(id, name, email);
        user.Raise(new UserCreatedDomainEvent(Guid.NewGuid(), DateTime.UtcNow, id));
        return user;
    }
    
    public void UpdateName(UserName name)
    {
        Name = name;
        //Raise(new UserNameUpdatedDomainEvent(Guid.NewGuid(), DateTime.UtcNow, Id, name));
    }
}
