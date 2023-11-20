using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace API.Controllers;

[Route("api/categoria")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly AppDataContext _context;

    public CategoriaController(AppDataContext context) =>
        _context = context;

    // GET: api/categoria/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Categoria> categorias = _context.Categorias.ToList();
            return Ok(categorias);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    [Route("listar/status/{concluidas:float}")]
    
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Categoria categoria)
    {
        try
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Created("", categoria);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPatch]
    [Route("alterar/{id}")]
        public IActionResult Alterar([FromRoute] int id, Categoria categoria)
        {
            try
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return Ok(categoria);
            }
            catch
            {
                return NotFound();
            }
        }
}
