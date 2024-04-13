using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using dotenv.net;

using DesafioSeniorSistemas.Domain.Pessoa.Interface;
using DesafioSeniorSistemas.Domain.Pessoa.Service;
using DesafioSeniorSistemas.Infrastructure.Logger;
using DesafioSeniorSistemas.Infrastructure.Repository.Context;
using DesafioSeniorSistemas.Infrastructure.Repository.Pessoa;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPessoaService>(
    provider => new PessoaService(
        pessoaRepository: new PessoaRepository(
            context: new MemoryDbContext()
        ),
        logger: new ConsoleWriteLineLogger()
    )
);

// Configuração da autenticação JWT
string key = Environment.GetEnvironmentVariable("JWT_TOKEN_KEY") ?? throw new ArgumentNullException("Jwt:Key");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Desafio Senior Sistemas API", 
        Version = "v1" 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
