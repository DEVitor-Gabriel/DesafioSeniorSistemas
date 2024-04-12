namespace DesafioSeniorSistemas.Domain.Pessoa.DTO
{
    public class ReadPessoaDtoOutput
    {
        public Guid Id { get; set; }
        public required string Codigo { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public required string Uf { get; set; }
        public required DateTime DataNascimento { get; set; }
    }
}