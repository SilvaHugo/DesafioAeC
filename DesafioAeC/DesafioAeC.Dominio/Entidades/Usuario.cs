﻿using DesafioAeC.Dominio.Entidades.Base;

namespace DesafioAeC.Dominio.Entities
{
    public class Usuario : EntidadeBase
    {
        public string? Nome {  get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
    }
}
