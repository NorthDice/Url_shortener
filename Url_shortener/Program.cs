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

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddAutoMapper(typeof(UserMapper).Assembly);

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();

services.AddScoped<UserService>();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(connection));

services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
services.Configure<AuthorizationOptions>(builder.Configuration.GetSection(nameof(AuthorizationOptions)));

//services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shortener API", Version = "v1" });
//});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthorization();
app.UseAuthentication();

//app.UseSwagger(); // Добавлено для включения Swagger middleware
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shortener API V1");
//    c.RoutePrefix = string.Empty;
//});

app.Run();
