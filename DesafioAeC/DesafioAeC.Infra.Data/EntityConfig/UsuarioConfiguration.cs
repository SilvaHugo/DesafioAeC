using DesafioAeC.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DesafioAeC.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Nome)
                .IsRequired();

            Property(x => x.Login)
                .IsRequired();

            Property(x => x.Senha)
                .IsRequired();
        }
    }
}
