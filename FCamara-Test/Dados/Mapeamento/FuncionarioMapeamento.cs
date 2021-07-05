using FCamara_Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCamara_Test.Dados.Mapeamento
{
    public class FuncionarioMapeamento : BaseMapeamento<Funcionario>, IEntityTypeConfiguration<Funcionario>
    {
        public new void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Nome).HasMaxLength(255);
            builder.Property(b => b.CPF).HasMaxLength(11);
            builder.Property(b => b.DataNascimento);
            builder.Property(b => b.Sexo);
            builder.Property(b => b.Cep).HasMaxLength(8);
            builder.Property(b => b.Endereco).HasMaxLength(100);
            builder.Property(b => b.Bairro).HasMaxLength(60);
            builder.Property(b => b.Numero).HasMaxLength(20);
            builder.Property(b => b.Complemento).HasMaxLength(40);
            builder.Property(b => b.Estado).HasMaxLength(20);
            builder.Property(b => b.Estado).HasMaxLength(40);
        }
    }
}
