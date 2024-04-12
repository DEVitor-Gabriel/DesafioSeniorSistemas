using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using DesafioSeniorSistemas.Domain.Pessoa.Interface;
using DesafioSeniorSistemas.Domain.Pessoa.DTO;

namespace DesafioSeniorSistemas.Infrastructure.API.Controller;


[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpGet("GetAll")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        List<ReadPessoaDtoOutput> output = await _pessoaService.GetAll();
        return Ok(output);
    }
}