namespace DesafioSeniorSistemas.Domain.Pessoa.DTO
{
    public class CreatePessoaDtoInput
    {
        public required string Codigo { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public required string UF { get; set; }
        public required DateTime DataNascimento { get; set; }
    }
}