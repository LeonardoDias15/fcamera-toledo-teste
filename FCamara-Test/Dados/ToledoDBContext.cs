using FCamara_Test.Dados.Mapeamento;
using FCamara_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace FCamara_Test.Dados
{
    public class ToledoDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<DependenteFuncionario> DependenteFuncionario { get; set; }
        public DbSet<HistoricoAuditoria> HistoricoAuditoria { get; set; }

        public ToledoDBContext(DbContextOptions<ToledoDBContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMapeamento());
            modelBuilder.ApplyConfiguration(new DependenteFuncionarioMapeamento());
            modelBuilder.ApplyConfiguration(new HistoricoAuditoriaMapeamento());

            base.OnModelCreating(modelBuilder);
        }
    }
}
