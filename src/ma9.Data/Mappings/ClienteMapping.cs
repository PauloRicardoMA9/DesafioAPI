using ma9.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ma9.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(cliente => cliente.Id);

            builder.Property(cliente => cliente.Nome)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(cliente => cliente.Sobrenome)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(cliente => cliente.Sexo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(cliente => cliente.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.HasOne(cliente => cliente.Contato)
                .WithOne(contato => contato.Cliente);

            builder.ToTable("Clientes");
        }
    }
}
