using Microsoft.EntityFrameworkCore;

using DesafioSeniorSistemas.Domain.Pessoa.Entity;
using DesafioSeniorSistemas.Domain.Pessoa.Interface;
using DesafioSeniorSistemas.Infrastructure.Repository.Context;
using DesafioSeniorSistemas.Infrastructure.Repository.Model;
using DesafioSeniorSistemas.Domain.Pessoa.Factory;

namespace DesafioSeniorSistemas.Infrastructure.Repository.Pessoa;

public class PessoaRepository : IPessoaRepository
{
    private readonly MemoryDbContext _context;

    public PessoaRepository(MemoryDbContext context)
    {
        _context = context;
    }

    private static PessoaEntity UsingFactory(PessoaModel pessoaModel) => PessoaFactory.Create(
        id: pessoaModel.Id,
        codigo: pessoaModel.Codigo,
        nome: pessoaModel.Nome,
        cpf: pessoaModel.CPF,
        uf: pessoaModel.UF,
        dataNascimento: pessoaModel.DataNascimento
    );
    public async Task<List<PessoaEntity>> GetAll()
    {
        List<PessoaModel> listPessoaModel = await _context.Pessoa.ToListAsync();
        List<PessoaEntity> listPessoaEntity = new();

        foreach (var pessoaModel in listPessoaModel)
        {
            listPessoaEntity.Add(UsingFactory(pessoaModel));
        }

        return listPessoaEntity;
    }

    public async Task<PessoaEntity?> GetById(Guid id)
    {
        PessoaModel? pessoaModel = await _context.Pessoa.FirstOrDefaultAsync(p => p.Id == id);

        if (pessoaModel == null)
        {
            return null;
        }

        return UsingFactory(pessoaModel);
    }

    public async Task<PessoaEntity?> GetByCodigo(long codigo)
    {
        PessoaModel? pessoaModel = await _context.Pessoa.FirstOrDefaultAsync(p => p.Codigo == codigo);

        if (pessoaModel == null)
        {
            return null;
        }

        return UsingFactory(pessoaModel);
    }

    public async Task<List<PessoaEntity>> GetByUf(string uf)
    {
        List<PessoaModel> listPessoaModel = await _context.Pessoa.Where(p => p.UF == uf).ToListAsync();
        List<PessoaEntity> listPessoaEntity = new();

        foreach (var pessoaModel in listPessoaModel)
        {
            listPessoaEntity.Add(UsingFactory(pessoaModel));
        }

        return listPessoaEntity;
    }

    public async Task<PessoaEntity> Create(PessoaEntity pessoaEntity)
    {
        PessoaModel pessoaModel = new()
        {
            Id = pessoaEntity.Id,
            Codigo = pessoaEntity.Codigo,
            Nome = pessoaEntity.Nome,
            CPF = pessoaEntity.CPF.Numero,
            UF = pessoaEntity.UF,
            DataNascimento = pessoaEntity.DataNascimento
        };

        await _context.Pessoa.AddAsync(pessoaModel);
        await _context.SaveChangesAsync();

        return UsingFactory(pessoaModel);
    }

    public async Task<PessoaEntity> Update(PessoaEntity pessoaEntity)
    {
        PessoaModel pessoaModel = await _context.Pessoa.FirstOrDefaultAsync(p => p.Id == pessoaEntity.Id) ?? throw new KeyNotFoundException("Pessoa não encontrada");

        pessoaModel.Codigo = pessoaEntity.Codigo;
        pessoaModel.Nome = pessoaEntity.Nome;
        pessoaModel.CPF = pessoaEntity.CPF.Numero;
        pessoaModel.UF = pessoaEntity.UF;
        pessoaModel.DataNascimento = pessoaEntity.DataNascimento;

        _context.Pessoa.Update(pessoaModel);
        await _context.SaveChangesAsync();

        return UsingFactory(pessoaModel);
    }

    public async Task Delete(PessoaEntity pessoaEntity)
    {
        PessoaModel pessoaModel = await _context.Pessoa.FirstOrDefaultAsync(p => p.Id == pessoaEntity.Id) ?? throw new KeyNotFoundException("Pessoa não encontrada");

        _context.Pessoa.Remove(pessoaModel);
        await _context.SaveChangesAsync();
    }

    public async Task<long> GetNextCodigo()
    {
        try
        {
            long? maxCodigo = await _context.Pessoa.MaxAsync(p => p.Codigo);
            return maxCodigo.GetValueOrDefault() + 1;
        }
        catch (InvalidOperationException)
        {
            return 1;
        }
    }
}