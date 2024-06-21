using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace DesafioAeC.Infra.Data.Contexto
{
    public class DesafioAeCContexto : DbContext
    {
        public DesafioAeCContexto(DbContextOptions<DesafioAeCContexto> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove pluralização dos nomes das tabelas
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            // Remove exclusão em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Definir campos com o nome Id como Primary Key
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.Id);

            // Definir campos do tipo string como varchar
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(255)");
            }

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CriadoEm") != null))
            {
                // Define data de criação por padrão a data atual
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                }

                // Não deixa alterar a data de criação em updates
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CriadoEm").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Id") != null))
            {
                // Gera um novo GUID no insert
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Id").CurrentValue = Guid.NewGuid();
                }

                // Não deixa alterar o Id em updates
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Id").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UsuarioId") != null))
            {
                // Não deixa alterar o Id em updates
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UsuarioId").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("AlteradoEm") != null))
            {
                // Define data de alteração por padrão a data atual
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("AlteradoEm").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
