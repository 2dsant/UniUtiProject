//using Microsoft.EntityFrameworkCore;
//using UniUti.Database;
//using UniUti.Domain.Models;
//using Xunit;

//namespace UniUti.Test.InfraData.Tests.Repositories
//{
//    public class DisciplinaRepositoryTest
//    {
//        private readonly DbContextOptions<ApplicationDbContext> options;

//        public DisciplinaRepositoryTest()
//        {

//            options = new DbContextOptionsBuilder<ApplicationDbContext>()
//              .UseInMemoryDatabase(databaseName: "UniUtiDatabaseDisciplina")
//              .Options;

//            using (var context = new ApplicationDbContext(options))
//            {
//                context.Disciplinas.Add(new Disciplina
//                {
//                    Id = 1,
//                    Nome = "Disciplina Teste 01",
//                    Descricao = "Disciplina de teste.",
//                    Deletado = false
//                });

//                context.Disciplinas.Add(new Disciplina
//                {
//                    Id = 2,
//                    Nome = "Disciplina Teste 02",
//                    Descricao = "Disciplina de teste.",
//                    Deletado = false
//                });
//                context.SaveChanges();
//            }
//        }

//        [Fact]
//        public async Task Find_all_should_return_disciplinas()
//        {
//            var disciplinaList = new List<Disciplina>();

//            using (var context = new ApplicationDbContext(options))
//            {
//                disciplinaList = await context.Disciplinas.Where(i =>
//                    i.Deletado == false).ToListAsync();
//            }

//            Assert.True(disciplinaList.Any());
//        }

//        [Fact]
//        public async Task Find_by_id_should_return_disciplina()
//        {
//            var disciplina = new Disciplina();

//            using (var context = new ApplicationDbContext(options))
//            {
//                disciplina = await context.Disciplinas.Where(i =>
//                    i.Deletado == false && i.Id == 2).FirstOrDefaultAsync();
//            }

//            Assert.Equal("Disciplina Teste 02", disciplina.Nome);
//            Assert.Equal(2, disciplina.Id);
//        }

//        [Fact]
//        public async Task Create_should_success()
//        {
//            var disciplina = new Disciplina
//                {
//                    Id = 4,
//                    Nome = "Disciplina Teste 04",
//                    Descricao = "Disciplina de teste.",
//                    Deletado = false
//                };
//            var result = new Disciplina();

//            using (var context = new ApplicationDbContext(options))
//            {
//                context.Disciplinas.Add(disciplina);
//                context.SaveChanges();
//            }
//            using (var context = new ApplicationDbContext(options))
//            {
//                disciplina = context.Disciplinas.Where(x => x.Id == 4).FirstOrDefault();
//            }

//            Assert.Equal("Disciplina Teste 04", disciplina.Nome);
//            Assert.Equal(4, disciplina.Id);
//        }

//        [Fact]
//        public async Task Update_should_success()
//        {
//            var disciplina = new Disciplina
//            {
//                Id = 2,
//                Nome = "Update Disciplina Teste 02",
//                Descricao = "Disciplina de teste.",
//                Deletado = false
//            };
//            var result = new Disciplina();

//            using (var context = new ApplicationDbContext(options))
//            {
//                context.Disciplinas.Update(disciplina);
//                context.SaveChanges();
//            }
//            using (var context = new ApplicationDbContext(options))
//            {
//                disciplina = context.Disciplinas.Where(x => x.Id == 2).FirstOrDefault();
//            }

//            Assert.Equal("Update Disciplina Teste 02", disciplina.Nome);
//        }

//        [Fact]
//        public async Task Delete_should_success()
//        {
//            var disciplina = new Disciplina();
//            using (var context = new ApplicationDbContext(options))
//            {
//                var disciplinaBd = context.Disciplinas.Where(x => x.Id == 1).FirstOrDefault();
//                disciplinaBd.Deletado = true;
//                context.SaveChanges();
//            }
//            using (var context = new ApplicationDbContext(options))
//            {
//                disciplina = context.Disciplinas.Where(x => x.Id == 1).FirstOrDefault();
//            }

//            Assert.True(disciplina.Deletado);
//        }
//    }
//}
