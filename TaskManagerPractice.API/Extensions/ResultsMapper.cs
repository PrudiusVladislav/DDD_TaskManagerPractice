using TaskManagerPractice.Domain.SharedKernel.Result;

namespace TaskManagerPractice.API.Extensions;

public static class ResultsMapper
{
    public static IResult MapFailureResult(IList<Error> resultErrors)
    {
        var firstError = resultErrors.FirstOrDefault();

        return firstError?.Type switch
        {
            ErrorType.Conflict => Results.Conflict(firstError.Message),
            ErrorType.NotFound => Results.NotFound(firstError.Message),
            ErrorType.BusinessRuleViolation => Results.BadRequest(resultErrors.Select(e => 
                new { errorType = e.Type.ToString(), errorMessage = e.Message })),
            ErrorType.Unauthorized => Results.Unauthorized(),
            _ => Results.BadRequest("An unexpected error occurred")
        };
    }
}