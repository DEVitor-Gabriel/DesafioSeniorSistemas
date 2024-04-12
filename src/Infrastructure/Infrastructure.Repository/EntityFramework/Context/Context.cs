using DesafioSeniorSistemas.Infrastructure.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DesafioSeniorSistemas.Infrastructure.Repository.Context;

public class MemoryDbContext : DbContext
{
    public DbSet<PessoaModel> Pessoa { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("DesafioSeniorSistemasDbMemory");
    }
}
