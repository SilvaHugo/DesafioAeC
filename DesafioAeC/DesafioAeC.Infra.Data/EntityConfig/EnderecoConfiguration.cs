using DesafioAeC.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAeC.Infra.Data.EntityConfig
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Bairro)
                .IsRequired();

            builder.Property(x => x.Cep)
                .IsRequired();

            builder.Property(x => x.Cidade)
                .IsRequired();

            builder.Property(x => x.Complemento)
                .IsRequired(false);

            builder.Property(x => x.Logradouro)
                .IsRequired();

            builder.Property(x => x.Numero)
                .IsRequired();

            builder.Property(x => x.Uf)
                .IsRequired();

            builder.Property(x => x.UsuarioId)
                .IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithMany(u => u.Enderecos)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); //remover a exclusão em cascata
        }
    }
}
