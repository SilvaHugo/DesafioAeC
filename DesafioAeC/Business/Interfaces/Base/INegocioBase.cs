namespace DesafioAeC.Business.Interfaces.Base
{
    public interface INegocioBase<TEntidade> where TEntidade : class
    {
        void Inserir(TEntidade obj);
        TEntidade ObterPorId(Guid id);
        IEnumerable<TEntidade> ObterTodos();
        void Alterar(TEntidade obj);
        void Remover(TEntidade obj);
        void Dispose();
    }
}
