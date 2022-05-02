using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniUti.models
{
    public class Curso
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public Instituicao? Instituicao { get; set; }
        public ICollection<Disciplina>? Disciplinas { get; set; }
    }
}