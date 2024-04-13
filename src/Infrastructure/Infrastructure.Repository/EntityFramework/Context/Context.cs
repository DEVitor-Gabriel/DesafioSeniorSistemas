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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PessoaModel>().HasKey(p => new { p.Id, p.Codigo });

        modelBuilder.Entity<PessoaModel>().Property(p => p.Id).IsRequired();
        modelBuilder.Entity<PessoaModel>().Property(p => p.Codigo).IsRequired();
        modelBuilder.Entity<PessoaModel>().Property(p => p.Nome).IsRequired();
        modelBuilder.Entity<PessoaModel>().Property(p => p.CPF).IsRequired();
        modelBuilder.Entity<PessoaModel>().Property(p => p.UF).IsRequired();
        modelBuilder.Entity<PessoaModel>().Property(p => p.DataNascimento).IsRequired();
    }
}
