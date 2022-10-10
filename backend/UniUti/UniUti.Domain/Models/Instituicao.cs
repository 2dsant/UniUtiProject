using System.ComponentModel.DataAnnotations.Schema;
using UniUti.Domain.Models.Base;
using UniUti.Domain.Models.Validator;

namespace UniUti.Domain.Models
{
    public class Instituicao : EntidadeBase
    {
        public string? Nome { get; private set; }
        [NotMapped]
        public ICollection<string>? UsuariosId { get; private set; }
        [NotMapped]
        public EnderecoInstituicao? Endereco { get; private set; }
        public ICollection<EnderecoInstituicao>? Enderecos { get; private set; }
        public string? Telefone { get; private set; }
        public string? Email { get; private set; }
        public string? Celular { get; private set; }
        public Boolean Deletado { get; private set; } = false;

        protected Instituicao() { }

        public Instituicao(Guid? id, string nome, List<string>? usuariosId, EnderecoInstituicao endereco, 
            List<EnderecoInstituicao>? enderecos, string telefone, string email, string celular, bool? deletado = false)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id.Value;
            Nome = nome;
            UsuariosId = usuariosId;
            Endereco = endereco;
            Enderecos = enderecos;
            Telefone = telefone;
            Email = email;
            Celular = celular;
            Deletado = deletado.Value;
            Validate();
        }

        public Instituicao(Guid id, string nome,EnderecoInstituicao endereco,
            string telefone, string email, string celular, bool? deletado = false)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Celular = celular;
            Deletado = deletado.Value;
            Validate();
        }

        public bool Validate()
            => base.Validate<InstituicaoValidator, Instituicao>(new InstituicaoValidator(), this);

        public void SetNome(string nome)
        {
            Nome = nome;
            Validate();
        }

        public void SetId()
        {
            Id = Guid.NewGuid();
        }
        public void SetUsuario(List<string> usuariosId)
        {
            UsuariosId = usuariosId;
            Validate();
        }

        public void SetEndereco(EnderecoInstituicao endereco)
        {
            Endereco = endereco;
            Validate();
        }

        public void SetEnderecos(List<EnderecoInstituicao> enderecos)
        {
            Enderecos = enderecos;
            Validate();
        }

        public void SetTelefone(string telefone)
        {
            Telefone = telefone;
            Validate();
        }

        public void SetEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void SetCelular(string celular)
        {
            Celular = celular;
            Validate();
        }

        public void SetDeletado(bool value)
        {
            Deletado = value;
            Validate();
        }
    }
}