using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciamentoFuncionarios.Models;

namespace GerenciamentoFuncionarios.Models
{
    public class GerenciamentoFuncionariosContext : DbContext
    {
        public GerenciamentoFuncionariosContext (DbContextOptions<GerenciamentoFuncionariosContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Funcionario>().HasOne(f => f.Lotacao).WithMany(l => l.Funcionarios);

        }
        public DbSet<GerenciamentoFuncionarios.Models.Departamento> Departamento { get; set; }

        public DbSet<GerenciamentoFuncionarios.Models.Funcionario> Funcionario { get; set; }

        public DbSet<GerenciamentoFuncionarios.Models.Tarefa> Tarefa { get; set; }
    }
}
