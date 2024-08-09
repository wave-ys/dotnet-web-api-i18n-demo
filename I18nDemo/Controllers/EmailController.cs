using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace I18nDemo.Controllers;

[ApiController]
[Route("email")]
public class EmailController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] [EmailAddress(ErrorMessage = "InvalidEmail")] string address)
    {
        return Ok(address);
    }
}