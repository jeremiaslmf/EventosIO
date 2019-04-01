using Eventos.IO.Domain.Models.Organizadores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.IO.Infrastructure.Data.Mappings
{
    public class OrganizadorMapping : IEntityTypeConfiguration<Organizador>
    {
        public void Configure(EntityTypeBuilder<Organizador> builder)
        {
            builder.ToTable("Organizadores");

            builder.Property(o => o.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(o => o.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(o => o.CPF)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);
        }
    }
}