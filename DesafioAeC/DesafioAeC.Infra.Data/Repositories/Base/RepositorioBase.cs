using DesafioAeC.Dominio.Interfaces.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace DesafioAeC.Infra.Data.Repositories.Base
{
    public class RepositorioBase<TEntidade> : IDisposable, IRepositorioBase<TEntidade>
        where TEntidade : class
    {
        protected DbContext Context { get; set; }

        public RepositorioBase(DbContext context)
        {
            Context = context;
        }

        public void Alterar(TEntidade obj)
        {
            Context.Set<TEntidade>().Update(obj);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            //throw new NotImplementedException();
        }

        public void Inserir(TEntidade obj)
        {
            Context.Set<TEntidade>().Add(obj);
            Context.SaveChanges();
        }

        public TEntidade ObterPorId(Guid id)
        {
            return Context.Set<TEntidade>().Find(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return Context.Set<TEntidade>().AsNoTracking();
        }

        public void Remover(TEntidade obj)
        {
            Context.Set<TEntidade>().Remove(obj);
            Context.SaveChanges();
        }
    }
}
