using FCamara_Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCamara_Test.Dados.Mapeamento
{
    public class DependenteFuncionarioMapeamento : BaseMapeamento<DependenteFuncionario>, IEntityTypeConfiguration<DependenteFuncionario>
    {
        public new void Configure(EntityTypeBuilder<DependenteFuncionario> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Nome).HasMaxLength(255);
            builder.Property(b => b.CPF).HasMaxLength(11);
            builder.Property(b => b.DataNascimento);
            builder.Property(b => b.Sexo);

            builder.HasOne(b => b.Funcionario).WithMany(b => b.DependenteFuncionarios).HasForeignKey(b => b.FuncionarioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
