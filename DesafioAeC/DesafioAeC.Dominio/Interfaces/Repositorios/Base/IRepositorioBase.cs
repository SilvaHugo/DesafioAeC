namespace DesafioAeC.Dominio.Interfaces.Repositorios.Base
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class
    {
        void Inserir(TEntidade obj);
        TEntidade ObterPorId(Guid id);
        IEnumerable<TEntidade> ObterTodos();
        void Alterar(TEntidade obj);
        void Remover(TEntidade obj);
        void Dispose();
    }
}
