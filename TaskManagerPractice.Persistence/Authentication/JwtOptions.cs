using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace TaskManagerPractice.Persistence.Authentication;

public class JwtOptions
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string Secret { get; init; }
    public SymmetricSecurityKey SigningKey => new(Encoding.UTF8.GetBytes(Secret));
};