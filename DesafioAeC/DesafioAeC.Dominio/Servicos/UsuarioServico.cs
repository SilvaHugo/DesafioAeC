﻿using DesafioAeC.Dominio.Entities;
using DesafioAeC.Dominio.Interfaces.Repositorios;
using DesafioAeC.Dominio.Interfaces.Servicos;
using DesafioAeC.Dominio.Servicos.Base;

namespace DesafioAeC.Dominio.Servicos
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioService
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
            : base(usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public bool AutenticarUsuario()
        {
            return _usuarioRepositorio.AutenticarUsuario();
        }
    }
}