using TaskManagerPractice.Domain.SharedKernel;

namespace TaskManagerPractice.Domain.Users;

public record UserId(Guid Value): TypedIdBase(Value);