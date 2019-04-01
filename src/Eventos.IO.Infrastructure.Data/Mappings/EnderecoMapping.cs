using Eventos.IO.Domain.Models.Eventos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.IO.Infrastructure.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            #region Tipagem

            builder.Property(e => e.Logradouro)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e=> e.Numero)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.CEP)
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(e => e.Cidade)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();


            #endregion

            #region Relacionamento
            builder
                .HasOne(e => e.Evento)
                .WithOne(e => e.Endereco)
                .HasForeignKey<Endereco>(e => e.EventoId)
                .IsRequired(false);
            #endregion

            #region Membros Ignorados
            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);
            #endregion
        }
    }
}
