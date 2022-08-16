using UniUti.Domain.Models.Enum;

namespace UniUti.Application.ValueObjects
{
    public class MonitoriaResponseVO
    {
        public long? Id { get; set; }
        public string SolicitanteId { get; set; }
        public string PrestadorId { get; set; }
        public string? Descricao { get; set; }
        public DisciplinaResponseVO? Disciplina { get; set; }
        public DateTime? DataCriacao { get; set; }
        public TipoSolicitacao TipoSolicitacao { get; set; }
        public StatusSolicitacao? StatusSolicitacaco { get; set; }
    }
}