using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using FluentValidation.Results;
using UniUti.Domain.Models;
using System.Text;

namespace UniUti.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? NomeCompleto { get; set; }
        public string? Celular { get; set; }
        public Guid? InstituicaoId { get; set; }
        public Guid? CursoId { get; set; }
        public ICollection<Monitoria>? MonitoriasSolicitadas { get; set; }
        public ICollection<Monitoria>? MonitoriasOfertadas { get; set; }
        public ICollection<EnderecoUsuario>? Enderecos { get; set; }
        [NotMapped]
        public EnderecoUsuario? Endereco { get; set; }
        public Instituicao? Instituicao { get; set; }
        public Curso? Curso { get; set; }
        public Boolean Deletado { get; set; } = false;

        //validação
        internal List<string> _errors = new List<string>();
        public IReadOnlyCollection<string> Errors => _errors;
        public bool IsValid => _errors.Count == 0;

        protected ApplicationUser() { }

        public ApplicationUser(string id, string nomeCompleto, string email, string celular, Guid? instituicaoId, Guid? cursoId, 
            ICollection<Monitoria>? monitoriasSolicitadas, ICollection<Monitoria>? monitoriasOfertadas, 
            ICollection<EnderecoUsuario>? enderecos, EnderecoUsuario endereco, Instituicao? instituicao, Curso? curso, bool? deletado = false)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Celular = celular;
            InstituicaoId = instituicaoId;
            CursoId = cursoId;
            MonitoriasSolicitadas = monitoriasSolicitadas;
            MonitoriasOfertadas = monitoriasOfertadas;
            Enderecos = enderecos;
            Endereco = endereco;
            Instituicao = instituicao;
            Curso = curso;
            Deletado = deletado.Value;
            UserName = email;
            Email = email;
            PhoneNumber = celular;
            EmailConfirmed = true;
        }

        private void AddErrorsList(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                _errors.Add(error.ErrorMessage);
            }
        }

        public bool Validate()
        {
            var validator = new ApplicationUserValidator();
            var validation = validator.Validate(this);
            if (validation.Errors.Count > 0)
                AddErrorsList(validation.Errors);

            return IsValid;
        }

        public string ErrorsToString()
        {
            var builder = new StringBuilder();

            foreach (var error in _errors)
                builder.AppendLine(error);

            return builder.ToString();
        }
    }
}
