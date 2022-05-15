

using UniUti.models.enums;

namespace UniUti.models
{
    public class Monitoria
    {
        public int Id { get; set; }
        public Usuario? Solicitante { get; set; }
        public Usuario? Prestador { get; set; }
        public string? Descricao { get; set; }
        public Disciplina? Disciplina { get; set; }
        public DateTime? DataCriacao { get; set; }
        public StatusSolicitacao? StatusSolicitacaco { get; set; }
    }
}