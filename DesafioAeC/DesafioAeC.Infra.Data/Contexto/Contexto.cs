using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Entities;
using DesafioAeC.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DesafioAeC.Infra.Data.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("DesafioAeC")
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove a pluralização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //definir campos com o nome Id como Primary Key
            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            //definir campos do tipo string como varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //definir tamanho de campos do tipo string para 255
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CriadoEm") != null))
            {
                //define data de criacao por padrão a data atual
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                }

                //não deixa alterar a data de criação em updates
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CriadoEm").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
