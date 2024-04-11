namespace DesafioSeniorSistemas.Domain.Pessoa.Entity;

public class PessoaEntity {
    private readonly Guid _id;
    public Guid Id => _id;
    private string _codigo;
    public string Codigo => _codigo;
    private string _nome;
    public string Nome => _nome;
    private ValueObject.CPF _cpf;
    public ValueObject.CPF CPF => _cpf;
    private string _uf;
    public string UF => _uf;
    private DateTime _dataNascimento;
    public DateTime DataNascimento => _dataNascimento;

    public PessoaEntity(Guid id, string codigo, string nome, ValueObject.CPF cpf, string uf, DateTime dataNascimento)
    {
        _id = id;
        _codigo = codigo;
        _nome = nome;
        _cpf = cpf;
        _uf = uf;
        _dataNascimento = dataNascimento;
    }

    public void Change(string codigo, string nome, ValueObject.CPF cpf, string uf, DateTime dataNascimento)
    {
        _codigo = codigo;
        _nome = nome;
        _cpf = cpf;
        _uf = uf;
        _dataNascimento = dataNascimento;
    }

    public void ChangeCodigo(string codigo)
    {
        _codigo = codigo;
    }

    public void ChangeNome(string nome)
    {
        _nome = nome;
    }

    public void ChangeCPF(ValueObject.CPF cpf)
    {
        _cpf = cpf;
    }

    public void ChangeCPF(string cpf)
    {
        _cpf = new ValueObject.CPF(cpf);
    }

    public void ChangeUF(string uf)
    {
        _uf = uf;
    }

    public void ChangeDataNascimento(DateTime dataNascimento)
    {
        _dataNascimento = dataNascimento;
    }
}