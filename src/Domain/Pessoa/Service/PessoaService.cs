using DesafioSeniorSistemas.Domain.Interface;
using DesafioSeniorSistemas.Domain.Pessoa.Entity;
using DesafioSeniorSistemas.Domain.Pessoa.Factory;
using DesafioSeniorSistemas.Domain.Pessoa.Interface;
using Domain.Exception;

namespace DesafioSeniorSistemas.Domain.Pessoa.Service;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ILogger _logger;

    public PessoaService(IPessoaRepository pessoaRepository, ILogger logger)
    {
        _pessoaRepository = pessoaRepository;
        _logger = logger;
    }
    public async Task<List<PessoaEntity>> GetAll()
    {
        List<PessoaEntity> listPessoa  = await _pessoaRepository.GetAll();
        return listPessoa;
    }

    public async Task<PessoaEntity> GetByCodigo(string codigo)
    {
        PessoaEntity pessoa = await _pessoaRepository.GetByCodigo(codigo: codigo);
        return pessoa;
    }

    public async Task<List<PessoaEntity>> GetByUf(string uf)
    {
        List<PessoaEntity> listPessoa = await _pessoaRepository.GetByUf(uf: uf);
        return listPessoa;
    }

    public async Task<PessoaEntity> Create(string codigo, string nome, string cpf, string uf, DateTime dataNascimento)
    {
        PessoaEntity pessoa = PessoaFactory.Create(
            id: Guid.NewGuid(),
            codigo: codigo,
            nome: nome,
            cpf: cpf,
            uf: uf,
            dataNascimento: dataNascimento
        );

        await _pessoaRepository.Create(entity: pessoa);
        _logger.Info("Pessoa criada com sucesso");

        return pessoa;
    }

    public async Task<PessoaEntity> Update(Guid id, string codigo, string nome, string cpf, string uf, DateTime dataNascimento)
    {
        PessoaEntity pessoa = await _pessoaRepository.GetById(id: id) ?? throw new NotFoundException("Pessoa não encontrada");

        PessoaEntity pessoaFactory = PessoaFactory.Create(
            id: id,
            codigo: codigo,
            nome: nome,
            cpf: cpf,
            uf: uf,
            dataNascimento: dataNascimento
        );

        await _pessoaRepository.Update(entity: pessoaFactory);
        _logger.Info("Pessoa atualizada com sucesso");

        return pessoa;
        
    }

    public async Task<PessoaEntity> UpdatePatch(Guid id, string? codigo, string? nome, string? cpf, string? uf, DateTime? dataNascimento)
    {
        PessoaEntity pessoa = await _pessoaRepository.GetById(id: id) ?? throw new NotFoundException("Pessoa não encontrada");
        
        if (codigo != null)
        {
            pessoa.ChangeCodigo(codigo: codigo);
            _logger.Info("Código alterado");
        
        }
        if (nome != null)
        {
            pessoa.ChangeNome(nome: nome);
            _logger.Info("Nome alterado");
        }
        if (cpf != null)
        {
            pessoa.ChangeCPF(cpf: cpf);
            _logger.Info("CPF alterado");
        }
        if (uf != null)
        {
            pessoa.ChangeUF(uf: uf);
            _logger.Info("UF alterado");
        }
        if (dataNascimento != null)
        {
            pessoa.ChangeDataNascimento(dataNascimento: (DateTime)dataNascimento);
            _logger.Info("Data de nascimento alterada");
        }

        await _pessoaRepository.Update(entity: pessoa);
        _logger.Info("Pessoa atualizada com sucesso");

        return pessoa;

    }

    public async Task Delete(Guid id)
    {
        _logger.Warning("Deletando pessoa");
        PessoaEntity pessoa = await _pessoaRepository.GetById(id) ?? throw new NotFoundException("Pessoa não encontrada");

        await _pessoaRepository.Delete(entity: pessoa);
        _logger.Info("Pessoa deletada com sucesso");
    }


}