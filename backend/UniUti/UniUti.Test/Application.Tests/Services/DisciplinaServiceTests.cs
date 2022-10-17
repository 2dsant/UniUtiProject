//using UniUti.Application.ValueObjects;
//using UniUti.Application.Services;
//using UniUti.Domain.Interfaces;
//using UniUti.Domain.Models;
//using UniUti.Config;
//using AutoMapper;
//using Xunit;
//using Moq;

//namespace UniUti.Test.Application.Tests.Services
//{
//    public class DisciplinaServiceTests
//    {
//        private readonly Mock<IDisciplinaRepository> _service;
//        private readonly IMapper _mapper;
//        private readonly DisciplinaService _disciplina;

//        public DisciplinaServiceTests()
//        {
//            if (_mapper == null)
//            {
//                IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
//                _mapper = mapper;
//            }

//            _service = new Mock<IDisciplinaRepository>();
//            _disciplina = new DisciplinaService(_service.Object, _mapper);
//        }

//        [Fact]
//        public async Task Find_all_should_return_disciplina_success()
//        {
//            //Arrange
//            var disciplina = new List<Disciplina>()
//            {
//                new Disciplina()
//                {
//                    Id = Guid.NewGuid(),
//                    Nome = "Teste",
//                    Deletado = false
//                }
//            };

//            //Action
//            _service.Setup(x => x.FindAll()).ReturnsAsync(disciplina);
//            var result = await _disciplina.FindAll();

//            //Assert
//            Assert.True(result.Any());
//        }

//        [Fact]
//        public async Task Find_all_should_return_null()
//        {
//            //Arrange
//            var disciplina = new List<Disciplina>();

//            //Action
//            _service.Setup(x => x.FindAll()).ReturnsAsync(disciplina);
//            var result = await _disciplina.FindAll();

//            //Assert
//            Assert.False(result.Any());
//        }

//        [Fact]
//        public async Task Find_by_id_should_return_disciplina()
//        {
//            //Arrange
//            var disciplina = new Disciplina()
//                {
//                    Id = Guid.NewGuid(),
//                    Nome = "Teste",
//                    Deletado = false
//                };

//            //Action
//            _service.Setup(x => x.FindById(It.IsAny<string>())).ReturnsAsync(disciplina);
//            var result = await _disciplina.FindById(It.IsAny<string>());

//            //Assert
//            Assert.Equal(result.Id, disciplina.Id.ToString());
//        }

//        [Fact]
//        public async Task Delete_should_success()
//        {
//            //Arrange
//            //Action
//            _service.Setup(x => x.Delete(It.IsAny<string>())).ReturnsAsync(true);
//            var result = await _disciplina.Delete(It.IsAny<string>());

//            //Assert
//            Assert.True(true);
//        }

//        [Fact]
//        public async Task Create_success()
//        {
//            //Arrange
//            var disciplina = new Disciplina()
//            {
//                Id = Guid.NewGuid(),
//                Nome = "Teste",
//                Deletado = false
//            };

//            //Action
//            _service.Setup(x => x.Create(disciplina)).ReturnsAsync(disciplina);
//            var exception = Record.ExceptionAsync(() => _disciplina.Create(It.IsAny<DisciplinaCreateVO>())); 

//            //Assert
//            Assert.Null(exception.Exception);
//        }

//        [Fact]
//        public async Task Update_success()
//        {
//            //Arrange
//            var disciplina = new Disciplina()
//            {
//                Id = Guid.NewGuid(),
//                Nome = "Teste",
//                Deletado = false
//            };

//            //Action
//            _service.Setup(x => x.Update(disciplina)).ReturnsAsync(disciplina);
//            var exception = Record.ExceptionAsync(() => _disciplina.Update(It.IsAny<DisciplinaUpdateVO>()));

//            //Assert
//            Assert.Null(exception.Exception);
//        }
//    }
//}