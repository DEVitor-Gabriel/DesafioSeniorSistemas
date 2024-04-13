using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DesafioSeniorSistemas.Infrastructure.Repository.Model;

public class PessoaModel
{
    [Key]
    public Guid Id { get; set; }
    [Key]
    [Required]
    public required long Codigo { get; set; }
    public required string Nome { get; set; }
    public required string CPF { get; set; }
    public required string UF { get; set; }
    public required DateTime DataNascimento { get; set; }
}
