using ALL.Database;
using Microsoft.EntityFrameworkCore;
using URLshortner.Controllers;
using URLshortner.Repositories;
using URLshortner.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database
builder.Services.AddDbContext<AppDbContext>(
     bd => bd.UseSqlServer(
         "server=LEGIONFORELSALE;database=URLDB;integrated security=true;trust server certificate=True;")
);

// Add Database repositories
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<FriendRepository>();
builder.Services.AddScoped<UrlRepository>();

// Add Services
builder.Services.AddScoped<TokenGenerator>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UrlService>();
builder.Services.AddScoped<FriendService>();

var jwtSettings = builder.Configuration;
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = jwtSettings["JwtSettings:Issuer"],
        ValidAudience = jwtSettings["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["JwtSettings:SecretKey"]))
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();