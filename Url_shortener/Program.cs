using System.Diagnostics;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Url_shortener.Application.Interfaces;
using Url_shortener.Application.Services;
using Url_shortener.Logic.Interfaces;
using Url_shortener.Logic.Models;
using Url_shortener.Logic.Models.JWT;
using Url_shortener.Persistence.Data;
using Url_shortener.Persistence.Mapper;
using Url_shortener.Persistence.Repositories;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddHttpContextAccessor();

services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5175")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

services.AddAutoMapper(typeof(UserMapper).Assembly);

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();
services.AddScoped<IUrlRepository, UrlRepository>();
services.AddScoped<IUrlShorteningService, UrlShorteningService>();
services.AddScoped<UserService>();
services.AddScoped<UrlService>();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connection));

services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
services.Configure<AuthorizationOptions>(builder.Configuration.GetSection(nameof(AuthorizationOptions)));

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shortener API", Version = "v1" });
});

var app = builder.Build();


var frontendPath = @"C:\Users\usuario\Desktop\HTML Projects\Url_shortener\url_shortener";

var reactDevServer = new ProcessStartInfo
{
    FileName = "cmd.exe",
    Arguments = "/c npm run dev",
    WorkingDirectory = frontendPath,
    RedirectStandardOutput = true,
    RedirectStandardError = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

try
{
    Process.Start(reactDevServer);
    Console.WriteLine("Frontend (React) server started...");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to start frontend server: {ex.Message}");
}

Task.Run(() => Process.Start(new ProcessStartInfo
{
    FileName = "http://localhost:5175/table",
    UseShellExecute = true
}));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthorization();
app.UseAuthentication();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shortener API V1");
});

app.MapControllers();

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});
var logger = loggerFactory.CreateLogger<Program>();

app.Run();
