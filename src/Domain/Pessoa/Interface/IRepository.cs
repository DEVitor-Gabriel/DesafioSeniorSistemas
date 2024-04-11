using DesafioSeniorSistemas.Domain.Pessoa.Entity;
using DesafioSeniorSistemas.Domain.Interface;

namespace DesafioSeniorSistemas.Domain.Pessoa.Interface;

public interface IPessoaRepository : IRepository<PessoaEntity>
{
    Task<List<PessoaEntity>> GetByUf(string uf);
    Task<PessoaEntity> GetByCodigo(string codigo);
}