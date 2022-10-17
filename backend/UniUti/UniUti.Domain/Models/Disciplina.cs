using UniUti.Domain.Models.Validator;
using UniUti.Domain.Models.Base;

namespace UniUti.Domain.Models
{
    public class Disciplina : EntidadeBase
    {
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public ICollection<Monitoria>? Monitorias { get; private set; }
        public Boolean Deletado { get; private set; } = false;

        protected Disciplina() { }

        public Disciplina(Guid? id, string nome, string descricao, List<Monitoria>? monitorias, bool? deletado = false)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id.Value;
            Nome = nome;
            Descricao = descricao;
            Monitorias = monitorias;
            Deletado = deletado.Value;
            Validate();
        }

        public bool Validate()
            => base.Validate<DisciplinaValidator, Disciplina>(new DisciplinaValidator(), this);

        public void SetNome(string nome)
        {
            Nome = nome;
            Validate();
        }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
            Validate();
        }

        public void SetId()
        {
            Id = Guid.NewGuid();
        }

        public void SetMonitoria(List<Monitoria> monitorias)
        {
            Monitorias = monitorias;
            Validate();
        }

        public void SetDeletado(bool value)
        {
            Deletado = value;
            Validate();
        }
    }
}