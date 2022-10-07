using Microsoft.AspNetCore.Mvc;
using WebAppProva.Models;

namespace WebAppProva.Controllers;

public class FuncionarioController : Controller
{

    private readonly DataContext _ctx;

    public FuncionarioController(DataContext ctx)
    {
        _ctx = ctx;
    }
    
    
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar([FromBody]Funcionario funcionario)
    {
        try
        {
            funcionario.CriadoEm = DateTime.Now;
            _ctx.Funcionarios.Add(funcionario);
            _ctx.SaveChanges();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    public IActionResult Listar()
    {
        return Ok();
    }

    public IActionResult Buscar()
    {
        return Ok();
    }
    
}