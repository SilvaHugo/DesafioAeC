using DesafioAeC.Business.Interfaces.Base;
using DesafioAeC.Dominio.Interfaces.Servicos.Base;

namespace DesafioAeC.Business.Negocio.Base
{
    public class NegocioBase<TEntidade> : IDisposable, INegocioBase<TEntidade> where TEntidade : class
    {
        private readonly IServiceBase<TEntidade> _serviceBase;

        public NegocioBase(IServiceBase<TEntidade> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Alterar(TEntidade obj)
        {
            _serviceBase.Alterar(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public void Inserir(TEntidade obj)
        {
            _serviceBase.Inserir(obj);
        }

        public TEntidade ObterPorId(Guid id)
        {
            return _serviceBase.ObterPorId(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _serviceBase.ObterTodos();
        }

        public void Remover(TEntidade obj)
        {
            _serviceBase.Remover(obj);
        }
    }
}
