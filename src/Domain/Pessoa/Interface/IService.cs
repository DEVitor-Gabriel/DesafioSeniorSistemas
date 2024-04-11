namespace DesafioSeniorSistemas.Domain.Pessoa.Interface;

using DesafioSeniorSistemas.Domain.Pessoa.Entity;

public interface IPessoaService
{
    Task<List<PessoaEntity>> GetAll();
    Task<PessoaEntity> GetByCodigo(string codigo);
    Task<List<PessoaEntity>> GetByUf(string uf);
    Task<PessoaEntity> Create(string codigo, string nome, string cpf, string uf, DateTime dataNascimento);
    Task<PessoaEntity> Update(Guid id, string codigo, string nome, string cpf, string uf, DateTime dataNascimento);
    Task<PessoaEntity> UpdatePatch(Guid id, string? codigo, string? nome, string? cpf, string? uf, DateTime? dataNascimento);
    Task Delete(Guid id);
}