

namespace UniUti.models
{
    public class Instituicao
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<Curso>? Cursos { get; set; }
        public Endereco? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
    }
}