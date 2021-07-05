using FCamara_Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCamara_Test.Dados.Mapeamento
{
    public class BaseMapeamento<T> where T : Entidade
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(builder => builder.Id);
            builder.Property(builder => builder.Ativo).HasDefaultValue("true");
            builder.Property(builder => builder.DataCadastro).HasDefaultValueSql("getdate()"); ;
            builder.Property(builder => builder.DataAtualizacao);
        }
    }
}
