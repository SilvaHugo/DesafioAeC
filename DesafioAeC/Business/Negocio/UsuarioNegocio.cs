using Business.Interfaces;
using Business.Negocio.Base;
using DesafioAeC.Dominio.Entities;
using DesafioAeC.Dominio.Interfaces.Servicos;
using DesafioAeC.Dominio.Interfaces.Servicos.Base;

namespace Business.Negocio
{
    public class UsuarioNegocio : NegocioBase<Usuario>, IUsuarioNegocio
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioNegocio(IUsuarioService usuarioService) 
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public bool AutenticarUsuario()
        {
            return _usuarioService.AutenticarUsuario();
        }
    }
}
