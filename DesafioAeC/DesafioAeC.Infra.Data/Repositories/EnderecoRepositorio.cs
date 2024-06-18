﻿using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Repositorios;
using DesafioAeC.Infra.Data.Contexto;
using DesafioAeC.Infra.Data.Repositories.Base;

namespace DesafioAeC.Infra.Data.Repositories
{
    public class EnderecoRepositorio : RepositorioBase<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(DesafioAeCContexto context) : base(context)
        {
        }
    }
}
