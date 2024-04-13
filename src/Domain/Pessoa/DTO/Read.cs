namespace DesafioSeniorSistemas.Domain.Pessoa.DTO;
public class ReadPessoaDtoOutput
{
    public required long Codigo { get; set; }
    public required string Nome { get; set; }
    public required string CPF { get; set; }
    public required string UF { get; set; }
    public required DateTime DataNascimento { get; set; }
}