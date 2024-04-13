namespace DesafioSeniorSistemas.Domain.Pessoa.Interface;

using DesafioSeniorSistemas.Domain.Pessoa.DTO;

public interface IPessoaService
{
    Task<List<ReadPessoaDtoOutput>> GetAll();
    Task<ReadPessoaDtoOutput> GetByCodigo(string codigo);
    Task<List<ReadPessoaDtoOutput>> GetByUf(string uf);
    Task<ReadPessoaDtoOutput> Create(CreatePessoaDtoInput dto);
    Task<ReadPessoaDtoOutput> Update(UpdatePessoaDtoInput dto);
    Task<ReadPessoaDtoOutput> UpdatePatch(UpdatePatchPessoaDtoInput dto);
    Task Delete(Guid id);
}