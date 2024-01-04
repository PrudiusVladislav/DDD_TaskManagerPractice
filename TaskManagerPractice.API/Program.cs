using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TaskManagerPractice.API.Extensions;
using TaskManagerPractice.API.Middleware;
using TaskManagerPractice.API.OptionsSetup;
using TaskManagerPractice.Application;
using TaskManagerPractice.Persistence;
using TaskManagerPractice.Persistence.Authentication;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddTransient<ErrorHandlingMiddleware>()
        .AddPersistence(builder.Configuration)
        .AddApplication();
    
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
            };
        });
    
    builder.Services.AddAuthorization();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseMiddleware<ErrorHandlingMiddleware>();
    
    app.UseAuthentication();
    app.UseAuthorization();
    
    app.MapUserEndpoints();
    app.MapTaskEndpoints();
}

app.Run();

