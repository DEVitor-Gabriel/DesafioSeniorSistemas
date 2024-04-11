using DesafioSeniorSistemas.Domain.Pessoa.Entity;

namespace DesafioSeniorSistemas.Domain.Pessoa.Factory;

public class PessoaFactory
{
    public static PessoaEntity Create(
        Guid? id,
        string codigo,
        string nome,
        string cpf,
        string uf,
        DateTime dataNascimento
    )
    {

        ValueObject.CPF cpfValueObject = new(cpf);

        PessoaEntity pessoa = new(
            id: id ?? Guid.NewGuid(),
            codigo: codigo,
            nome: nome,
            cpf: cpfValueObject,
            uf: uf,
            dataNascimento: dataNascimento
        );

        return pessoa;
    }
}