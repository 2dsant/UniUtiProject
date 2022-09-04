using UniUti.Application.ValueObjects;
using UniUti.Application.Services;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using UniUti.Config;
using AutoMapper;
using Xunit;
using Moq;

namespace UniUti.Test.Application.Tests.Services
{
    public class CursoServiceTests
    {
        private readonly Mock<ICursoRepository> _service;
        private readonly IMapper _mapper;
        private readonly CursoService _curso;

        public CursoServiceTests()
        {
            if (_mapper == null)
            {
                IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
                _mapper = mapper;
            }

            _service = new Mock<ICursoRepository>();
            _curso = new CursoService(_service.Object, _mapper);
        }

        [Fact]
        public async Task Find_all_should_return_curso_success()
        {
            //Arrange
            var curso = new List<Curso>()
            {
                new Curso()
                {
                    Id = 1,
                    Nome = "Teste",
                    Deletado = false
                }
            };

            //Action
            _service.Setup(x => x.FindAll()).ReturnsAsync(curso);
            var result = await _curso.FindAll();

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public async Task Find_all_should_return_null()
        {
            //Arrange
            var curso = new List<Curso>();

            //Action
            _service.Setup(x => x.FindAll()).ReturnsAsync(curso);
            var result = await _curso.FindAll();

            //Assert
            Assert.False(result.Any());
        }

        [Fact]
        public async Task Find_by_id_should_return_curso()
        {
            //Arrange
            var curso = new Curso()
                {
                    Id = 1,
                    Nome = "Teste",
                    Deletado = false
                };

            //Action
            _service.Setup(x => x.FindById(It.IsAny<long>())).ReturnsAsync(curso);
            var result = await _curso.FindById(It.IsAny<long>());

            //Assert
            Assert.Equal(result.Id, curso.Id);
        }

        [Fact]
        public async Task Delete_should_success()
        {
            //Arrange
            //Action
            _service.Setup(x => x.Delete(It.IsAny<long>())).ReturnsAsync(true);
            var result = await _curso.Delete(It.IsAny<long>());

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async Task Create_success()
        {
            //Arrange
            var curso = new Curso()
            {
                Id = 1,
                Nome = "Teste",
                Deletado = false
            };

            //Action
            _service.Setup(x => x.Create(curso)).ReturnsAsync(curso);
            var exception = Record.ExceptionAsync(() => _curso.Create(It.IsAny<CursoCreateVO>())); 

            //Assert
            Assert.Null(exception.Exception);
        }

        [Fact]
        public async Task Update_success()
        {
            //Arrange
            var curso = new Curso()
            {
                Id = 1,
                Nome = "Teste",
                Deletado = false
            };

            //Action
            _service.Setup(x => x.Update(curso)).ReturnsAsync(curso);
            var exception = Record.ExceptionAsync(() => _curso.Update(It.IsAny<CursoResponseVO>()));

            //Assert
            Assert.Null(exception.Exception);
        }
    }
}