using UniUti.Domain.Models.Validator;
using UniUti.Domain.Models.Base;

namespace UniUti.Domain.Models
{
    public class EnderecoUsuario : EntidadeBase
    {
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? ApplicationUserId { get; set; }
        public bool? Deletado { get; set; } = false;

        protected EnderecoUsuario() { }

        public EnderecoUsuario(Guid? id, string cep, string rua, string numero, string cidade,
            string estado, string pais, string applicationUserId, bool? deletado = false)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id.Value;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            ApplicationUserId = applicationUserId;
            Deletado = deletado;
            Validate();
        }

        public bool Validate()
            => base.Validate<EnderecoUsuarioValidator, EnderecoUsuario>(new EnderecoUsuarioValidator(), this);

        public void SetCep(string cep)
        {
            Cep = cep;
            Validate();
        }

        public void SetId()
        {
            Id = Guid.NewGuid();
        }
        public void SetRua(string rua)
        {
            Rua = rua;
            Validate();
        }

        public void SetNumero(string numero)
        {
            Numero = numero;
            Validate();
        }

        public void SetCidade(string cidade)
        {
            Cidade = cidade;
            Validate();
        }

        public void SetPais(string pais)
        {
            Pais = pais;
            Validate();
        }

        public void SetEstado(string estado)
        {
            Estado = estado;
            Validate();
        }

        public void SetApplicationUserId(string id)
        {
            ApplicationUserId = id;
            Validate();
        }

        public void SetDeletado(bool value)
        {
            Deletado = value;
            Validate();
        }
    }
}
