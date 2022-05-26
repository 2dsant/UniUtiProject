using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniUti.models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public ICollection<Curso>? Cursos { get; set; }
        public Boolean Deletado { get; set; }
    }
}