using DesafioAeC.Dominio.Interfaces.Repositorios.Base;
using DesafioAeC.Infra.Data.Contexto;

namespace DesafioAeC.Infra.Data.Repositories.Base
{
    public class RepositorioBase<TEntidade> : IDisposable, IRepositorioBase<TEntidade>
        where TEntidade : class
    {
        protected DesafioAeCContexto Db = new DesafioAeCContexto();
        public void Alterar(TEntidade obj)
        {
            Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Inserir(TEntidade obj)
        {
            Db.Set<TEntidade>().Add(obj);
            Db.SaveChanges();
        }

        public TEntidade ObterPorId(Guid id)
        {
            return Db.Set<TEntidade>().Find(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return Db.Set<TEntidade>().ToList();
        }

        public void Remover(TEntidade obj)
        {
            Db.Set<TEntidade>().Remove(obj);
            Db.SaveChanges();
        }
    }
}
