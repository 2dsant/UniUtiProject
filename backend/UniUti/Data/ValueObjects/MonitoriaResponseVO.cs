using UniUti.models.Enum;

namespace UniUti.Data.ValueObjects
{
    public class MonitoriaResponseVO
    {
        public long? Id { get; set; }
        public UsuarioResponseVO? Solicitante { get; set; }
        public UsuarioResponseVO? Prestador { get; set; }
        public string? Descricao { get; set; }
        public DisciplinaResponseVO? Disciplina { get; set; }
        public DateTime? DataCriacao { get; set; }
        public StatusSolicitacao? StatusSolicitacaco { get; set; }
    }
}