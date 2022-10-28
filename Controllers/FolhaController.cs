using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppProva.Models;

namespace WebAppProva.Controllers;

public class FolhaController : Controller
{
    private readonly DataContext _ctx;

    public FolhaController(DataContext ctx)
    {
        _ctx = ctx;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Cadastrar([FromBody]Folha folha)
    {
        try
        {
            folha.Funcionario = _ctx.Funcionarios.FirstOrDefault(x => x.FuncionarioId == folha.FuncionarioId);
            folha.SalarioBruto = folha.ValorHora * folha.QuantidadeDeHoras;
            folha.ImpostoFgts = folha.SalarioBruto * 0.08;

            folha.ImpostoDeRenda = folha.SalarioBruto switch
            {
                > 4664.68 => folha.SalarioBruto * 0.275,
                > 3751.06 => folha.SalarioBruto * 0.225,
                > 2826.66 => folha.SalarioBruto * 0.15,
                > 1903.99 => folha.SalarioBruto * 0.075,
                _ => 0
            };

            folha.ImpostoInss = folha.SalarioBruto switch
            {
                > 5645.81 => 621.03,
                > 2822.91 => folha.SalarioBruto * 0.11,
                > 1693.73 => folha.SalarioBruto * 0.09,
                _ => folha.SalarioBruto * 0.08
            };

            folha.SalarioLiquido = folha.SalarioBruto - (folha.ImpostoInss + folha.ImpostoDeRenda);
            folha.Data = DateTime.Today;
            _ctx.Folhas.Add(folha);
            _ctx.SaveChanges();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok(folha);
    }

    [HttpGet]
    [Route("Folha/Buscar/{cpf}/{mes:int}/{ano:int}")]
    public IActionResult Buscar([FromRoute] string cpf, [FromRoute] int mes, [FromRoute] int ano)
    {
        try
        {
            //_ctx.Folhas.FirstOrDefault(x => x.Funcionario.Cpf.Equals(cpf));
            foreach (var folha in _ctx.Folhas.Include(x => x.Funcionario).ToList())
            {
                if (folha.Funcionario.Cpf.Equals(cpf) && folha.Data.Month == mes && folha.Data.Year == ano)
                    return Ok(folha);
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NotFound();
    }

    [HttpGet]
    [Route("Folha/Filtrar/{ano:int}/{mes:int}")]
    public IActionResult Filtrar([FromRoute] int ano, [FromRoute] int mes)
    {
        try
        {
            return Ok(_ctx.Folhas.Include(x =>x.Funcionario).ToList().Where(x => x.Data.Month == mes && x.Data.Year == ano));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult Listar()
    {
        List<Folha> folhas = _ctx.Folhas.Include(x => x.Funcionario).ToList();
        return Ok(folhas);
    }
}