using DesafioSeniorSistemas.Domain.Interface;
using DesafioSeniorSistemas.Domain.Pessoa.DTO;
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
    public async Task<List<ReadPessoaDtoOutput>> GetAll()
    {
        List<PessoaEntity> listPessoa  = await _pessoaRepository.GetAll();
        List<ReadPessoaDtoOutput> listPessoaDto = listPessoa.Select(pessoa => new ReadPessoaDtoOutput
        {
            Id = pessoa.Id,
            Codigo = pessoa.Codigo,
            Nome = pessoa.Nome,
            Cpf = pessoa.CPF.Numero,
            Uf = pessoa.UF,
            DataNascimento = pessoa.DataNascimento
        }).ToList();

        return listPessoaDto;
    }

    public async Task<ReadPessoaDtoOutput> GetByCodigo(string codigo)
    {
        PessoaEntity pessoa = await _pessoaRepository.GetByCodigo(codigo: codigo);
        ReadPessoaDtoOutput pessoaDto = new()
        {
            Id = pessoa.Id,
            Codigo = pessoa.Codigo,
            Nome = pessoa.Nome,
            Cpf = pessoa.CPF.Numero,
            Uf = pessoa.UF,
            DataNascimento = pessoa.DataNascimento
        };

        return pessoaDto;

    }

    public async Task<List<ReadPessoaDtoOutput>> GetByUf(string uf)
    {
        List<PessoaEntity> listPessoa = await _pessoaRepository.GetByUf(uf: uf);
        List<ReadPessoaDtoOutput> listPessoaDto = listPessoa.Select(pessoa => new ReadPessoaDtoOutput
        {
            Id = pessoa.Id,
            Codigo = pessoa.Codigo,
            Nome = pessoa.Nome,
            Cpf = pessoa.CPF.Numero,
            Uf = pessoa.UF,
            DataNascimento = pessoa.DataNascimento
        }).ToList();

        return listPessoaDto;
    }

    public async Task<ReadPessoaDtoOutput> Create(string codigo, string nome, string cpf, string uf, DateTime dataNascimento)
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

        ReadPessoaDtoOutput pessoaDto = new()
        {
            Id = pessoa.Id,
            Codigo = pessoa.Codigo,
            Nome = pessoa.Nome,
            Cpf = pessoa.CPF.Numero,
            Uf = pessoa.UF,
            DataNascimento = pessoa.DataNascimento
        };

        return pessoaDto;
    }

    public async Task<ReadPessoaDtoOutput> Update(Guid id, string codigo, string nome, string cpf, string uf, DateTime dataNascimento)
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

        ReadPessoaDtoOutput pessoaDto = new()
        {
            Id = pessoaFactory.Id,
            Codigo = pessoaFactory.Codigo,
            Nome = pessoaFactory.Nome,
            Cpf = pessoaFactory.CPF.Numero,
            Uf = pessoaFactory.UF,
            DataNascimento = pessoaFactory.DataNascimento
        };

        return pessoaDto;
        
    }

    public async Task<ReadPessoaDtoOutput> UpdatePatch(Guid id, string? codigo, string? nome, string? cpf, string? uf, DateTime? dataNascimento)
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

        ReadPessoaDtoOutput pessoaDto = new()
        {
            Id = pessoa.Id,
            Codigo = pessoa.Codigo,
            Nome = pessoa.Nome,
            Cpf = pessoa.CPF.Numero,
            Uf = pessoa.UF,
            DataNascimento = pessoa.DataNascimento
        };

        return pessoaDto;

    }

    public async Task Delete(Guid id)
    {
        _logger.Warning("Deletando pessoa");
        PessoaEntity pessoa = await _pessoaRepository.GetById(id) ?? throw new NotFoundException("Pessoa não encontrada");

        await _pessoaRepository.Delete(entity: pessoa);
        _logger.Info("Pessoa deletada com sucesso");
    }


}