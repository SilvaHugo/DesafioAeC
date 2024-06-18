using DesafioAeC.Dominio.Interfaces.Repositorios.Base;
using DesafioAeC.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        }

        public void Dispose()
        {
            Context.Dispose();
            //throw new NotImplementedException();
        }

        public void Inserir(TEntidade obj)
        {
            Context.Set<TEntidade>().Add(obj);
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
        }
    }
}
