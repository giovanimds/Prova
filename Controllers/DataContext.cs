using Microsoft.EntityFrameworkCore;
using WebAppProva.Models;

namespace WebAppProva.Controllers;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Folha>()
            .HasOne<Funcionario>()
            .WithMany(x => x.Folhas)
            .HasForeignKey(x => x.FuncionarioId);
    }

    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Folha> Folhas { get; set; }
    
}