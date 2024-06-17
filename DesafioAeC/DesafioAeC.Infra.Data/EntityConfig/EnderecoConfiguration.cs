using DesafioAeC.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace DesafioAeC.Infra.Data.EntityConfig
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Bairro)
                .IsRequired();

            Property(x => x.Cep)
                .IsRequired();

            Property(x => x.Cidade)
                .IsRequired();

            Property(x => x.Complemento)
                .IsOptional();

            Property(x => x.Logradouro)
                .IsRequired();

            Property(x => x.Numero)
                .IsRequired();

            Property(x => x.Uf)
                .IsRequired();

            Property(x => x.UsuarioId)
                .IsRequired();

            HasRequired(x => x.Usuario)
            .WithMany(u => u.Enderecos)
            .HasForeignKey(x => x.UsuarioId);
        }
    }
}
