using Business.Interfaces.Base;
using DesafioAeC.Dominio.Entities;

namespace Business.Interfaces
{
    public interface IUsuarioNegocio : INegocioBase<Usuario>
    {
        public bool AutenticarUsuario();
    }
}
