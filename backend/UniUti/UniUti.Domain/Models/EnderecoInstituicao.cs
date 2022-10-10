using UniUti.Domain.Models.Validator;
using UniUti.Domain.Models.Base;

namespace UniUti.Domain.Models
{
    public class EnderecoInstituicao : EntidadeBase
    {
        public string? Cep { get; private set; }
        public string? Rua { get; private set; }
        public string? Numero { get; private set; }
        public string? Cidade { get; private set; }
        public string? Estado { get; private set; }
        public string? Pais { get; private set; }
        public Guid? InstituicaoId { get; private set; }
        public Instituicao? Instituicao { get; private set; }
        public bool? Deletado { get; private set; } = false;

        protected EnderecoInstituicao() { }

        public EnderecoInstituicao(Guid? id, string cep, string rua, string numero, string cidade, 
            string estado, string pais, Instituicao instituicao, bool? deletado = false)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id.Value;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Instituicao = instituicao;
            InstituicaoId = Instituicao.Id;
            Deletado = deletado;
            Validate();
        }

        public bool Validate()
            => base.Validate<EnderecoInstituicaoValidator, EnderecoInstituicao>(new EnderecoInstituicaoValidator(), this);

        public void SetCep(string cep)
        {
            Cep = cep;
            Validate();
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

        public void SetId()
        {
            Id = Guid.NewGuid();
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

        public void SetInstituicaoId(string id)
        {
            InstituicaoId = Guid.Parse(id);
            Validate();
        }

        public void SetInstituicao(Instituicao instituicao)
        {
            Instituicao = instituicao;
            Validate();
        }

        public void SetDeletado(bool value)
        {
            Deletado = value;
            Validate();
        }
    }
}