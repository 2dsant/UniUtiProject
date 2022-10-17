using UniUti.Domain.Models.Base;
using UniUti.Domain.Models.Validator;

namespace UniUti.Domain.Models
{
    public class Usuario : EntidadeBase
    {
        public string? NomeCompleto { get; private set; }
        public string? Password { get; private set; }
        public string? Email { get; private set; }
        public string? Celular { get; private set; }
        public Guid? InstituicaoId { get; private set; }
        public Guid? CursoId { get; private set; }
        public ICollection<Monitoria>? MonitoriasSolicitadas { get; set; }
        public ICollection<Monitoria>? MonitoriasOfertadas { get; set; }
        public List<EnderecoUsuario>? Enderecos { get; set; }
        public EnderecoUsuario? Endereco { get; private set; }
        public Instituicao? Instituicao { get; private set; }
        public Curso? Curso { get; private set; }
        public Boolean Deletado { get; private set; } = false;

        protected Usuario() { }

        public Usuario(Guid? id, string nomeCompleto, string password, string email, List<Monitoria>? monitoriasSolicitadas, 
            List<Monitoria>? monitoriasOfertadas, string? celular, List<EnderecoUsuario>? enderecos,
            EnderecoUsuario? endereco, Instituicao? instituicao, Curso? curso, bool deletado = false)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id.Value;
            NomeCompleto = nomeCompleto;
            Password = password;
            Email = email;
            Celular = celular;
            MonitoriasOfertadas = monitoriasOfertadas;
            MonitoriasSolicitadas = monitoriasSolicitadas;
            InstituicaoId = Instituicao?.Id;
            CursoId = Curso?.Id;
            Enderecos = enderecos;
            Endereco = endereco;
            Instituicao = instituicao;
            Curso = curso;
            Deletado = deletado;
            Validate();
        }

        public bool Validate()
            => base.Validate<UsuarioValidator, Usuario>(new UsuarioValidator(), this);

        public void SetNomeCompleto(string nome)
        {
            NomeCompleto = nome;
            Validate();
        }

        public void SetPassword(string password)
        {
            Password = password;
            Validate();
        }

        public void SetId()
        {
            Id = Guid.NewGuid();
        }

        public void SetMonitoriasOfertadas(List<Monitoria> monitorias)
        {
            MonitoriasOfertadas = monitorias;
            Validate();
        }
        public void SetMonitoriasSolicitadas(List<Monitoria> monitorias)
        {
            MonitoriasSolicitadas = monitorias;
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

        public void SetInstituicaoId(string id)
        {
            InstituicaoId = Guid.Parse(id);
            Validate();
        }

        public void SetCursoId(string id)
        {
            CursoId = Guid.Parse(id);
            Validate();
        }

        public void SetCurso(Curso curso)
        {
            Curso = curso;
            Validate();
        }

        public void SetInstituicao(Instituicao instituicao)
        {
            Instituicao = instituicao;
            Validate();
        }

        public void SetEndereco(EnderecoUsuario endereco)
        {
            Endereco = endereco;
            Validate();
        }

        public void SetEnderecos(List<EnderecoUsuario> enderecos)
        {
            Enderecos = enderecos;
            Validate();
        }

        public void SetDeletado(bool value)
        {
            Deletado = value;
            Validate();
        }
    }
}