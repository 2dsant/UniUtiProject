//using Microsoft.EntityFrameworkCore;
//using UniUti.Domain.Models;
//using UniUti.Database;
//using Xunit;
//using Microsoft.Extensions.DependencyInjection;

//namespace UniUti.Test.InfraData.Tests.Repositories
//{
//    public class CursoRepositoryTest
//    {
//        public ServiceCollection Services { get; private set; }
//        public ServiceProvider ServiceProvider { get; protected set; }

//        public CursoRepositoryTest()
//        {
//            Services = new ServiceCollection();

//            Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "UniUtiInMemoryCurso"),
//                ServiceLifetime.Transient,
//                ServiceLifetime.Transient);

//            ServiceProvider = Services.BuildServiceProvider();

//            using (var context = ServiceProvider.GetService<ApplicationDbContext>())
//            {
//                context.Cursos.Add(new Curso
//                {
//                    Id = 1,
//                    Nome = "Teste 01",
//                    Deletado = false
//                });

//                context.Cursos.Add(new Curso
//                {
//                    Id = 2,
//                    Nome = "Teste 02",
//                    Deletado = false
//                });
//                context.SaveChanges();
//            }
//        }

//        [Fact]
//        public async Task Find_all_should_return_curso()
//        {
//            var cursoList = new List<Curso>();

//            using (var context = ServiceProvider.GetService<ApplicationDbContext>())
//            {
//                cursoList = await context.Cursos.Where(i =>
//                    i.Deletado == false).ToListAsync();
//            }

//            Assert.True(cursoList.Any());
//        }

//        [Fact]
//        public async Task Find_by_id_should_return_curso()
//        {
//            var curso = new Curso();

//            using (var context = ServiceProvider.GetService<ApplicationDbContext>())
//            {
//                curso = await context.Cursos.Where(i =>
//                    i.Deletado == false && i.Id == 2).FirstOrDefaultAsync();
//            }

//            Assert.Equal("Teste 02", curso.Nome);
//            Assert.Equal(2, curso.Id);
//        }

//        //[Fact]
//        //public async Task Create_should_success()
//        //{
//        //    var curso = new Curso
//        //        {
//        //            Id = 4,
//        //            Nome = "Teste 04",
//        //            Deletado = false
//        //        };
//        //    var result = new Curso();

//        //    using (var context = new ApplicationDbContext(options))
//        //    {
//        //        context.Cursos.Add(curso);
//        //        context.SaveChanges();
//        //    }
//        //    using (var context = new ApplicationDbContext(options))
//        //    {
//        //        curso = context.Cursos.Where(x => x.Id == 4).FirstOrDefault();
//        //    }

//        //    Assert.Equal("Teste 04", curso.Nome);
//        //    Assert.Equal(4, curso.Id);
//        //}

//        //[Fact]
//        //public async Task Update_should_success()
//        //{
//        //    var curso = new Curso
//        //    {
//        //        Id = 2,
//        //        Nome = "Update Teste 02",
//        //        Deletado = false
//        //    };
//        //    var result = new Curso();

//        //    using (var context = new ApplicationDbContext(options))
//        //    {
//        //        context.Cursos.Update(curso);
//        //        context.SaveChanges();
//        //    }
//        //    using (var context = new ApplicationDbContext(options))
//        //    {
//        //        curso = context.Cursos.Where(x => x.Id == 2).FirstOrDefault();
//        //    }

//        //    Assert.Equal("Update Teste 02", curso.Nome);
//        //}

//        //[Fact]
//        //public async Task Delete_should_success()
//        //{
//        //    var curso = new Curso();
//        //    using (var context = new ApplicationDbContext(options))
//        //    {
//        //        var cursoBd = context.Cursos.Where(x => x.Id == 1).FirstOrDefault();
//        //        cursoBd.Deletado = true;
//        //        context.SaveChanges();
//        //    }
//        //    using (var context = new ApplicationDbContext(options))
//        //    {
//        //        curso = context.Cursos.Where(x => x.Id == 1).FirstOrDefault();
//        //    }

//        //    Assert.True(curso.Deletado);
//        //}
//    }
//}
