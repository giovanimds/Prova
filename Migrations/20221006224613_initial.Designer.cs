// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppProva.Controllers;

#nullable disable

namespace WebAppProva.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221006224613_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7");

            modelBuilder.Entity("WebAppProva.Models.Folha", b =>
                {
                    b.Property<int>("FolhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ImpostoDeRenda")
                        .HasColumnType("REAL");

                    b.Property<double>("ImpostoFgts")
                        .HasColumnType("REAL");

                    b.Property<double>("ImpostoInss")
                        .HasColumnType("REAL");

                    b.Property<double>("QuantidadeDeHoras")
                        .HasColumnType("REAL");

                    b.Property<double>("SalarioBruto")
                        .HasColumnType("REAL");

                    b.Property<double>("SalarioLiquido")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorHora")
                        .HasColumnType("REAL");

                    b.HasKey("FolhaId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Folha");
                });

            modelBuilder.Entity("WebAppProva.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("WebAppProva.Models.Folha", b =>
                {
                    b.HasOne("WebAppProva.Models.Funcionario", "Funcionario")
                        .WithMany("Folhas")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("WebAppProva.Models.Funcionario", b =>
                {
                    b.Navigation("Folhas");
                });
#pragma warning restore 612, 618
        }
    }
}
