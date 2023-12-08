using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace API.Controllers;

[Route("api/imc")]
[ApiController]
public class ImcController : ControllerBase
{
    private readonly AppDataContext _context;

    public ImcController(AppDataContext context) =>
        _context = context;

    // GET: api/imc/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Imc> imcs = _context.Imcs.ToList();
            return Ok(imcs);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Imc imc)
    {

        
        try
        {
            _context.Imcs.Add(imc);
            _context.SaveChanges();
            return Created("", imc);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
