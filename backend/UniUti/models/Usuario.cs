using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniUti.models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public byte[]? SenhaHash { get; set; }
        public byte[]? SenhaSalt { get; set; }
        public string? Celular { get; set; }
        public Instituicao? Instituicao { get; set; }
        public Curso? Curso { get; set; }
        public Boolean Deletado { get; set; }
    }
}