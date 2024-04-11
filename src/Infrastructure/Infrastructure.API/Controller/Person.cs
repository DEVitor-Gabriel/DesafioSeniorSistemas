using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace DesafioSeniorSistemas.Infrastructure.API.Controller;


[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    [HttpGet("GetAll")]
    [Authorize]
    public IActionResult GetAll()
    {
        return Ok();
    }
}