namespace WebAppProva.Models;

public class Folha
{
    public int FolhaId { get; set; }
    public double ValorHora { get; set; }
    public double QuantidadeDeHoras { get; set; }
    public double SalarioBruto { get; set; }
    public double ImpostoDeRenda { get; set; }
    public double ImpostoInss { get; set; }
    public double ImpostoFgts { get; set; }
    public double SalarioLiquido { get; set; }
    public DateTime Data { get; set; }

    public int FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
}