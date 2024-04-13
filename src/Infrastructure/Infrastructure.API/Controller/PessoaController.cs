using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using DesafioSeniorSistemas.Domain.Pessoa.Interface;
using DesafioSeniorSistemas.Domain.Pessoa.DTO;
using Domain.Exception;

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

    [HttpGet("GetByCodigo")]
    [Authorize]
    public async Task<IActionResult> GetByCodigo(string codigo)
    {
        try
        {
            ReadPessoaDtoOutput output = await _pessoaService.GetByCodigo(codigo);
            return Ok(output);
        }
        catch (NotFoundException)
        {
            return NotFound("Pessoa não encontrada");
        }
    }

    [HttpGet("GetByUf")]
    [Authorize]
    public async Task<IActionResult> GetByUf(string uf)
    {
        List<ReadPessoaDtoOutput> output = await _pessoaService.GetByUf(uf);
        return Ok(output);
    }

    [HttpPost("Create")]
    [Authorize]
    public async Task<IActionResult> Create(CreatePessoaDtoInput dto)
    {
        ReadPessoaDtoOutput output = await _pessoaService.Create(dto);
        return CreatedAtAction(nameof(GetByCodigo), new { codigo = output.Codigo }, output);
    }

    [HttpPut("Update")]
    [Authorize]
    public async Task<IActionResult> Update(UpdatePessoaDtoInput dto)
    {
        try
        {
            await _pessoaService.Update(dto);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound("Pessoa não encontrada");
        }
    }

    [HttpPatch("UpdatePatch")]
    [Authorize]
    public async Task<IActionResult> UpdatePatch(UpdatePatchPessoaDtoInput dto)
    {
        try
        {
            await _pessoaService.UpdatePatch(dto);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound("Pessoa não encontrada");
        }
    }

    [HttpDelete("Delete")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _pessoaService.Delete(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound("Pessoa não encontrada");
        }
    }

    
}