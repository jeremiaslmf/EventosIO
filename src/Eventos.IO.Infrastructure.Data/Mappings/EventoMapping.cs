using Eventos.IO.Domain.Models.Eventos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.IO.Infrastructure.Data.Mappings
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Eventos");

            #region Tipagem
            builder
                .Property(e => e.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(e => e.DescricaoCurta)
                .HasColumnType("varchar(150)");

            builder
                .Property(e => e.DescricaoLonga)
                .HasColumnType("varchar(150)");

            builder
                .Property(e => e.NomeDaEmpresa)
                .HasColumnType("varchar(150)")
                .IsRequired();
            #endregion

            #region Relacionamentos
            builder
                .HasOne(e => e.Organizador)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrganizadorId);

            builder
                .HasOne(e => e.Categoria)
                .WithMany(c => c.Eventos)
                .HasForeignKey(e => e.CategoriaId)
                .IsRequired(false);
            #endregion

            #region Membros ignorados
            builder
                .Ignore(e => e.ValidationResult);

            builder
                .Ignore(e => e.Tags);

            builder
                .Ignore(e => e.CascadeMode);
            #endregion
        }
    }
}
