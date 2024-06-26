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
        List<PessoaEntity> listPessoa = await _pessoaRepository.GetAll();
        List<ReadPessoaDtoOutput> listPessoaDto = listPessoa.Select(pessoa => new ReadPessoaDtoOutput
        {
            Codigo = pessoa.Codigo,
            Nome = pessoa.Nome,
            CPF = pessoa.CPF.Numero,
            UF = pessoa.UF,
            DataNascimento = pessoa.DataNascimento
        }).ToList();

        return listPessoaDto;
    }

    public async Task<ReadPessoaDtoOutput> GetByCodigo(long codigo)
    {
        try
        {
            PessoaEntity pessoa = await _pessoaRepository.GetByCodigo(codigo: codigo) ?? throw new KeyNotFoundException();
            ReadPessoaDtoOutput pessoaDto = new()
            {
                Codigo = pessoa.Codigo,
                Nome = pessoa.Nome,
                CPF = pessoa.CPF.Numero,
                UF = pessoa.UF,
                DataNascimento = pessoa.DataNascimento
            };

            return pessoaDto;
        }
        catch (KeyNotFoundException)
        {
            throw new NotFoundException("Pessoa não encontrada");
        }

    }

    public async Task<List<ReadPessoaDtoOutput>> GetByUf(string uf)
    {
        List<PessoaEntity> listPessoa = await _pessoaRepository.GetByUf(uf: uf);
        List<ReadPessoaDtoOutput> listPessoaDto = listPessoa.Select(pessoa => new ReadPessoaDtoOutput
        {
            Codigo = pessoa.Codigo,
            Nome = pessoa.Nome,
            CPF = pessoa.CPF.Numero,
            UF = pessoa.UF,
            DataNascimento = pessoa.DataNascimento
        }).ToList();

        return listPessoaDto;
    }

    public async Task<ReadPessoaDtoOutput> Create(CreatePessoaDtoInput dto)
    {
        PessoaEntity pessoa = PessoaFactory.Create(
            id: Guid.NewGuid(),
            codigo: await _pessoaRepository.GetNextCodigo(),
            nome: dto.Nome,
            cpf: dto.CPF,
            uf: dto.UF,
            dataNascimento: dto.DataNascimento
        );

        await _pessoaRepository.Create(entity: pessoa);
        _logger.Info("Pessoa criada com sucesso");

        ReadPessoaDtoOutput pessoaDto = new()
        {
            Codigo = pessoa.Codigo,
            Nome = pessoa.Nome,
            CPF = pessoa.CPF.Numero,
            UF = pessoa.UF,
            DataNascimento = pessoa.DataNascimento
        };

        return pessoaDto;
    }

    public async Task<ReadPessoaDtoOutput> Update(UpdatePessoaDtoInput dto)
    {
        try
        {
            PessoaEntity pessoa = await _pessoaRepository.GetByCodigo(codigo: dto.Codigo) ?? throw new KeyNotFoundException();
            PessoaEntity pessoaFactory = PessoaFactory.Create(
                id: pessoa.Id,
                codigo: pessoa.Codigo,
                nome: dto.Nome,
                cpf: dto.CPF,
                uf: dto.UF,
                dataNascimento: dto.DataNascimento
            );

            await _pessoaRepository.Update(entity: pessoaFactory);
            _logger.Info("Pessoa atualizada com sucesso");

            ReadPessoaDtoOutput pessoaDto = new()
            {
                Codigo = pessoaFactory.Codigo,
                Nome = pessoaFactory.Nome,
                CPF = pessoaFactory.CPF.Numero,
                UF = pessoaFactory.UF,
                DataNascimento = pessoaFactory.DataNascimento
            };

            return pessoaDto;
        }
        catch (KeyNotFoundException)
        {
            throw new NotFoundException("Pessoa não encontrada");
        }
    }

    public async Task<ReadPessoaDtoOutput> UpdatePatch(UpdatePatchPessoaDtoInput dto)
    {
        try
        {
            PessoaEntity pessoa = await _pessoaRepository.GetByCodigo(codigo: dto.Codigo) ?? throw new KeyNotFoundException();

            if (dto.Nome != null)
            {
                pessoa.ChangeNome(nome: dto.Nome);
                _logger.Info("Nome alterado");
            }
            if (dto.CPF != null)
            {
                pessoa.ChangeCPF(cpf: dto.CPF);
                _logger.Info("CPF alterado");
            }
            if (dto.UF != null)
            {
                pessoa.ChangeUF(uf: dto.UF);
                _logger.Info("UF alterado");
            }
            if (dto.DataNascimento != null)
            {
                pessoa.ChangeDataNascimento(dataNascimento: (DateTime)dto.DataNascimento);
                _logger.Info("Data de nascimento alterada");
            }

            await _pessoaRepository.Update(entity: pessoa);
            _logger.Info("Pessoa atualizada com sucesso");

            ReadPessoaDtoOutput pessoaDto = new()
            {
                Codigo = pessoa.Codigo,
                Nome = pessoa.Nome,
                CPF = pessoa.CPF.Numero,
                UF = pessoa.UF,
                DataNascimento = pessoa.DataNascimento
            };

            return pessoaDto;
        }
        catch (KeyNotFoundException)
        {
            throw new NotFoundException("Pessoa não encontrada");
        }

    }

    public async Task Delete(long codigo)
    {
        try
        {
            _logger.Warning("Deletando pessoa");
            PessoaEntity pessoa = await _pessoaRepository.GetByCodigo(codigo: codigo) ?? throw new KeyNotFoundException();

            await _pessoaRepository.Delete(entity: pessoa);
            _logger.Info("Pessoa deletada com sucesso");

        }
        catch (KeyNotFoundException)
        {
            throw new NotFoundException("Pessoa não encontrada");
        }
    }


}