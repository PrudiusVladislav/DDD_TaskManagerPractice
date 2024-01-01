using TaskManagerPractice.Domain.SharedKernel;

namespace TaskManagerPractice.Domain.Tasks.ValueObjects;

public record TaskId(Guid Value): TypedIdBase(Value);