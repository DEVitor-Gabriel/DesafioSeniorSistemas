namespace DesafioSeniorSistemas.Domain.Pessoa.Interface;

using DesafioSeniorSistemas.Domain.Pessoa.DTO;
using DesafioSeniorSistemas.Domain.Pessoa.Entity;

public interface IPessoaService
{
    Task<List<ReadPessoaDtoOutput>> GetAll();
    Task<ReadPessoaDtoOutput> GetByCodigo(string codigo);
    Task<List<ReadPessoaDtoOutput>> GetByUf(string uf);
    Task<ReadPessoaDtoOutput> Create(string codigo, string nome, string cpf, string uf, DateTime dataNascimento);
    Task<ReadPessoaDtoOutput> Update(Guid id, string codigo, string nome, string cpf, string uf, DateTime dataNascimento);
    Task<ReadPessoaDtoOutput> UpdatePatch(Guid id, string? codigo, string? nome, string? cpf, string? uf, DateTime? dataNascimento);
    Task Delete(Guid id);
}