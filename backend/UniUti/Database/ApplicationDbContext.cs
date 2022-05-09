using Microsoft.EntityFrameworkCore;
using UniUti.models;

namespace UniUti.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Disciplina>? Disciplinas { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }
        public DbSet<Instituicao>? Instituicoes { get; set; }
        public DbSet<Monitoria>? Monitorias { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}