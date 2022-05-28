namespace UniUti.Data.ValueObjects
{
    public class EnderecoVO
    {
        public long Id { get; set; }
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
    }
}