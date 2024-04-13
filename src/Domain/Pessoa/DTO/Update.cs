namespace DesafioSeniorSistemas.Domain.Pessoa.DTO
{
    public class UpdatePessoaDtoInput
    {
        public Guid Id { get; set; }
        public required string Codigo { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public required string UF { get; set; }
        public required DateTime DataNascimento { get; set; }
    }

    public class UpdatePatchPessoaDtoInput
    {
        public Guid Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? UF { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}