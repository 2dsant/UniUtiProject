using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniUti.Infra.Data.Identity;
using UniUti.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace UniUti.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<EnderecoInstituicao> EnderecosInstituicao { get; set; }
        public DbSet<EnderecoUsuario> EnderecosUsuario { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Monitoria> Monitorias { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            // Curso
            mb.Entity<Curso>().HasKey(x => x.Id);
            mb.Entity<Curso>().Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nome");
            mb.Entity<Curso>().Property(x => x.Deletado)
                .HasColumnName("deletado");

            // Disciplina
            mb.Entity<Disciplina>().HasKey(x => x.Id);
            mb.Entity<Disciplina>().Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nome");
            mb.Entity<Disciplina>().Property(x => x.Deletado)
                .HasColumnName("deletado");

            // Endereço Instituicao
            mb.Entity<EnderecoInstituicao>().HasKey(x => x.Id);
            mb.Entity<EnderecoInstituicao>().Property(x => x.Cep)
                .HasMaxLength(8)
                .IsRequired()
                .HasColumnName("cep");
            mb.Entity<EnderecoInstituicao>().Property(x => x.Rua)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("rua");
            mb.Entity<EnderecoInstituicao>().Property(x => x.Numero)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnName("numero");
            mb.Entity<EnderecoInstituicao>().Property(x => x.Cidade)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("cidade");
            mb.Entity<EnderecoInstituicao>().Property(x => x.Estado)
                .HasMaxLength(2)
                .IsRequired()
                .HasColumnName("estado");
            mb.Entity<EnderecoInstituicao>().Property(x => x.Pais)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("pais");
            mb.Entity<EnderecoInstituicao>().Property(x => x.Deletado)
                .HasColumnName("deletado");

            // Endereço Usuario
            mb.Entity<EnderecoUsuario>().HasKey(x => x.Id);
            mb.Entity<EnderecoUsuario>().Property(x => x.Cep)
                .HasMaxLength(8)
                .IsRequired()
                .HasColumnName("cep");
            mb.Entity<EnderecoUsuario>().Property(x => x.Rua)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("rua");
            mb.Entity<EnderecoUsuario>().Property(x => x.Numero)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnName("numero");
            mb.Entity<EnderecoUsuario>().Property(x => x.Cidade)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("cidade");
            mb.Entity<EnderecoUsuario>().Property(x => x.Estado)
                .HasMaxLength(2)
                .IsRequired()
                .HasColumnName("estado");
            mb.Entity<EnderecoUsuario>().Property(x => x.Pais)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("pais");
            mb.Entity<EnderecoUsuario>().Property(x => x.Deletado)
                .HasColumnName("deletado");

            // Instituicao
            mb.Entity<Instituicao>().HasKey(x => x.Id);
            mb.Entity<Instituicao>().Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nome");
            mb.Entity<Instituicao>().Property(x => x.Telefone)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnName("telefone");
            mb.Entity<Instituicao>().Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("email");
            mb.Entity<Instituicao>().Property(x => x.Celular)
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnName("celular");
            mb.Entity<Instituicao>().Property(x => x.Deletado)
                .HasColumnName("deletado");

            // Usuario
            mb.Entity<ApplicationUser>().HasKey(x => x.Id);
            mb.Entity<ApplicationUser>().Property(x => x.NomeCompleto)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("nomeCompleto");
            mb.Entity<ApplicationUser>().Property(x => x.Celular)
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnName("celular");
            mb.Entity<ApplicationUser>().Property(x => x.Deletado)
                .HasColumnName("deletado");

            //Monitorias
            mb.Entity<Monitoria>().HasKey(x => x.Id);
            mb.Entity<Monitoria>().Property(x => x.SolicitanteId).IsRequired();
            mb.Entity<Monitoria>().Property(x => x.Descricao)
                .HasMaxLength(500)
                .IsRequired()
                .HasColumnName("descricao");
            mb.Entity<Monitoria>().Property(x => x.DataCriacao).IsRequired();
            mb.Entity<Monitoria>().Property(x => x.StatusSolicitacao)
                .IsRequired()
                .HasColumnName("status_solicitacao");
            mb.Entity<Monitoria>().Property(x => x.TipoSolicitacao)
                .IsRequired()
                .HasColumnName("tipo_solicitacao");

            //Relacionamentos
            mb.Entity<Instituicao>().HasMany(x => x.Enderecos).WithOne(x => x.Instituicao).HasForeignKey(x => x.InstituicaoId).IsRequired();
            mb.Entity<Disciplina>().HasMany(x => x.Monitorias).WithOne(x => x.Disciplina).HasForeignKey(x => x.DisciplinaId).IsRequired();
            mb.Entity<ApplicationUser>().HasOne(x => x.Instituicao).WithMany().HasForeignKey(x => x.InstituicaoId).IsRequired(false);
            mb.Entity<ApplicationUser>().HasOne(x => x.Curso).WithMany().HasForeignKey(x => x.CursoId).IsRequired(false);
            mb.Entity<ApplicationUser>().HasMany(x => x.MonitoriasSolicitadas).WithOne().HasForeignKey(x => x.SolicitanteId);
            mb.Entity<ApplicationUser>().HasMany(x => x.MonitoriasOfertadas).WithOne().HasForeignKey(x => x.PrestadorId);
            mb.Entity<ApplicationUser>().HasMany(x => x.Enderecos).WithOne().HasForeignKey(x => x.ApplicationUserId).IsRequired();
        }
    }
}