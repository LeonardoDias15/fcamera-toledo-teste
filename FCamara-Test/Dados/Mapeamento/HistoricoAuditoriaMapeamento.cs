using FCamara_Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCamara_Test.Dados.Mapeamento
{
    public class HistoricoAuditoriaMapeamento : BaseMapeamento<HistoricoAuditoria>, IEntityTypeConfiguration<HistoricoAuditoria>
    {
        public new void Configure(EntityTypeBuilder<HistoricoAuditoria> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Funcionalidade).HasMaxLength(30);
            builder.Property(b => b.Evento).HasMaxLength(20);
            builder.Property(b => b.Dados);
            builder.Property(b => b.IdentificadorFuncionalidade);
        }
    }
}
