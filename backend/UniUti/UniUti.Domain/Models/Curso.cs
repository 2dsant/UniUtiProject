using UniUti.Domain.Models.Validator;
using UniUti.Domain.Models.Base;

namespace UniUti.Domain.Models
{
    public class Curso : EntidadeBase
    {
        public string? Nome { get; private set; }
        public Boolean Deletado { get; private set; } = false;

        protected Curso() { }

        public Curso(Guid? id, string? nome, bool? deletado = false)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id.Value;
            Nome = nome;
            Deletado = deletado.Value;
            _errors = new List<string>();
            this.Validate();
        }

        public bool Validate()
            => base.Validate<CursoValidator, Curso>(new CursoValidator(), this);

        public void SetNome(string nome)
        {
            Nome = nome;
            Validate();
        }

        public void SetId()
        {
            Id = Guid.NewGuid();
        }
        public void SetDeletado(bool value)
        {
            Deletado = value;
            Validate();
        }
    }
}