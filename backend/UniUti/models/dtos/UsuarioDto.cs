using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniUti.models.dtos
{
    public class UsuarioDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Celular { get; set; }
    }
}