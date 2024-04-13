namespace DesafioSeniorSistemas.Domain.Pessoa.DTO;
public class UpdatePessoaDtoInput
{
    public required long Codigo { get; set; }
    public required string Nome { get; set; }
    public required string CPF { get; set; }
    public required string UF { get; set; }
    public required DateTime DataNascimento { get; set; }
}

public class UpdatePatchPessoaDtoInput
{
    public required long Codigo { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public string? UF { get; set; }
    public DateTime? DataNascimento { get; set; }
}