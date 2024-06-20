using DesafioAeC.Dominio.Interfaces.Repositorios.Base;
using DesafioAeC.Dominio.Interfaces.Servicos.Base;

namespace DesafioAeC.Dominio.Servicos.Base
{
    public class ServicoBase<TEntidade> : IDisposable, IServiceBase<TEntidade> where TEntidade : class
    {
        private readonly IRepositorioBase<TEntidade> _repositorioBase;

        public ServicoBase(IRepositorioBase<TEntidade> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public void Alterar(TEntidade obj)
        {
            _repositorioBase.Alterar(obj);
        }

        public void Inserir(TEntidade obj)
        {
            _repositorioBase.Inserir(obj);
        }

        public TEntidade ObterPorId(Guid id)
        {
            return _repositorioBase.ObterPorId(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _repositorioBase.ObterTodos();
        }

        public void Remover(TEntidade obj)
        {
            _repositorioBase.Remover(obj);
        }

        public void Dispose()
        {
            _repositorioBase.Dispose();
        }
    }
}
