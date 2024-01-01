namespace TaskManagerPractice.Application.Tasks;

public record TaskDto(
    Guid Id,
    string Name,
    Guid UserId,
    string Description,
    string Status,
    DateTime CreatedAt,
    DateTime? ClosedAt);