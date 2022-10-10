//using UniUti.Application.ValueObjects;
//using UniUti.Application.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using UniUti.Controllers;
//using Xunit;
//using Moq;

//namespace UniUti.Test.WebAPI.Tests.Controller
//{
//    public class DisciplinaControllerTest
//    {
//        private readonly Mock<IDisciplinaService> _serviceMock;
//        private readonly DisciplinaController _controller;

//        public DisciplinaControllerTest()
//        {
//            _serviceMock = new Mock<IDisciplinaService>();
//            _controller = new DisciplinaController(_serviceMock.Object);
//        }

//        [Fact]
//        public async Task Find_all_should_return_all_disciplinas()
//        {
//            //Arrange
//            var disciplinas = new List<DisciplinaResponseVO>()
//            {
//                new DisciplinaResponseVO()
//                {
//                    Id = Guid.NewGuid().ToString(),
//                    Nome = "Disciplina teste 01",
//                    Descricao = "Descrição Teste."
//                },
//                new DisciplinaResponseVO()
//                {
//                    Id = Guid.NewGuid().ToString(),
//                    Nome = "Descrição Teste.",
//                    Descricao = "Descrição Teste."
//                },
//                new DisciplinaResponseVO()
//                {
//                    Id = Guid.NewGuid().ToString(),
//                    Nome = "Descrição Teste.",
//                    Descricao = "Descrição Teste."
//                }
//            };

//            //Action
//            _serviceMock.Setup(x => x.FindAll()).ReturnsAsync(disciplinas);
//            var actionResult = await _controller.FindAll();
//            var result = actionResult.Result as OkObjectResult;

//            //Assert
//            Assert.NotNull(result.Value);
//            Assert.True(result.StatusCode == 200);
//        }

//        [Fact]
//        public async Task Find_all_should_return_not_found()
//        {
//            //Arrange
//            var disciplinas = new List<DisciplinaResponseVO>();

//            //Action
//            _serviceMock.Setup(x => x.FindAll()).ReturnsAsync(disciplinas);
//            var actionResult = await _controller.FindAll();
//            var result = actionResult.Result as NotFoundObjectResult;

//            //Assert
//            Assert.Null(result);
//        }

//        [Fact]
//        public async Task Find_all_should_return_bad_request()
//        {
//            //Arrange

//            //Action
//            _serviceMock.Setup(x => x.FindAll()).ThrowsAsync(new Exception());
//            var actionResult = await _controller.FindAll();
//            var result = actionResult.Result as BadRequestObjectResult;

//            //Assert
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task Find_by_id_should_return_a_curso()
//        {
//            //Arrange
//            var disciplina = new DisciplinaResponseVO()
//                {
//                    Id = Guid.NewGuid().ToString(),
//                    Nome = "Curso teste 01",
//                    Descricao = "Descrição Teste."
//                };

//            //Action
//            _serviceMock.Setup(x => x.FindById(It.IsAny<string>())).ReturnsAsync(disciplina);
//            var actionResult = await _controller.FindById(It.IsAny<string>());
//            var result = actionResult.Result as OkObjectResult;

//            //Assert
//            Assert.NotNull(result.Value);
//        }

//        [Fact]
//        public async Task Find_by_id_should_return_not_found()
//        {
//            //Arrange
//            var disciplina = new DisciplinaResponseVO();

//            //Action
//            _serviceMock.Setup(x => x.FindById(It.IsAny<string>())).ReturnsAsync(disciplina);
//            var actionResult = await _controller.FindById(It.IsAny<string>());
//            var result = actionResult.Result as NotFoundResult;

//            //Assert
//            Assert.Null(result);
//        }

//        [Fact]
//        public async Task Find_by_id_should_return_bad_request()
//        {
//            //Arrange

//            //Action
//            _serviceMock.Setup(x => x.FindById(It.IsAny<string>())).ThrowsAsync(new Exception());
//            var actionResult = await _controller.FindById(It.IsAny<string>());
//            var result = actionResult.Result as BadRequestObjectResult;

//            //Assert
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task Create_should_success()
//        {
//            //Arrange

//            //Action
//            _serviceMock.Setup(x => x.Create(It.IsAny<DisciplinaCreateVO>())).Verifiable();
//            var actionResult = await _controller.Create(It.IsAny<DisciplinaCreateVO>());

//            //Assert
//            _serviceMock.Verify(x => x.Create(It.IsAny<DisciplinaCreateVO>()), Times.Once);
//        }

//        [Fact]
//        public async Task Create_should_return_bad_request()
//        {
//            //Arrange

//            //Action
//            _serviceMock.Setup(x => x.Create(It.IsAny<DisciplinaCreateVO>())).ThrowsAsync(new Exception());
//            var actionResult = await _controller.Create(It.IsAny<DisciplinaCreateVO>());
//            var result = actionResult.Result as BadRequestObjectResult;

//            //Assert
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task Create_should_return_bad_request_invalid_model()
//        {
//            //Arrange
//            var disciplina = new DisciplinaCreateVO()
//            {
//                Nome = "Curso teste 01",
//                Descricao = "Descrição Teste."
//            };
//            _controller.ModelState.AddModelError("teste", "teste");

//            //Action
//            _serviceMock.Setup(x => x.Create(disciplina)).Verifiable();
//            var actionResult = await _controller.Create(disciplina);
//            var result = actionResult.Result as BadRequestObjectResult;

//            //Assert
//            _serviceMock.Verify(x => x.Create(It.IsAny<DisciplinaCreateVO>()), Times.Never);
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task Update_should_success()
//        {
//            //Arrange

//            //Action
//            _serviceMock.Setup(x => x.Update(It.IsAny<DisciplinaUpdateVO>())).Verifiable();
//            var actionResult = await _controller.Update(It.IsAny<DisciplinaUpdateVO>());

//            //Assert
//            _serviceMock.Verify(x => x.Update(It.IsAny<DisciplinaUpdateVO>()), Times.Once);
//        }

//        [Fact]
//        public async Task Update_should_return_bad_request()
//        {
//            //Arrange

//            //Action
//            _serviceMock.Setup(x => x.Update(It.IsAny<DisciplinaUpdateVO>())).ThrowsAsync(new Exception());
//            var actionResult = await _controller.Update(It.IsAny<DisciplinaUpdateVO>());
//            var result = actionResult.Result as BadRequestObjectResult;

//            //Assert
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task Update_should_return_bad_request_invalid_model()
//        {
//            //Arrange
//            var curso = new DisciplinaUpdateVO()
//            {
//                Id = 1,
//                Nome = "Curso teste 01",
//                Descricao = "Descrição Teste."
//            };
//            _controller.ModelState.AddModelError("teste", "teste");

//            //Action
//            _serviceMock.Setup(x => x.Update(curso)).Verifiable();
//            var actionResult = await _controller.Update(curso);
//            var result = actionResult.Result as BadRequestObjectResult;

//            //Assert
//            _serviceMock.Verify(x => x.Update(It.IsAny<DisciplinaUpdateVO>()), Times.Never);
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task Delete_should_return_a_curso()
//        {
//            //Arrange

//            //Action
//            _serviceMock.Setup(x => x.Delete(It.IsAny<string>())).ReturnsAsync(true);
//            var actionResult = await _controller.Delete(It.IsAny<string>());
//            var result = actionResult.Result as OkObjectResult;

//            //Assert
//            Assert.NotNull(result.Value);
//        }

//        [Fact]
//        public async Task Delete_should_return_not_found()
//        {
//            //Arrange

//            //Action
//            _serviceMock.Setup(x => x.Delete(It.IsAny<string>())).ReturnsAsync(false);
//            var actionResult = await _controller.Delete(It.IsAny<string>());
//            var result = actionResult.Result as NotFoundResult;

//            //Assert
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task Delete_should_return_bad_request()
//        {
//            //Arrange

//            //Action
//            _serviceMock.Setup(x => x.Delete(It.IsAny<string>())).ThrowsAsync(new Exception());
//            var actionResult = await _controller.Delete(It.IsAny<string>());
//            var result = actionResult.Result as BadRequestObjectResult;

//            //Assert
//            Assert.NotNull(result);
//        }
//    }
//}
