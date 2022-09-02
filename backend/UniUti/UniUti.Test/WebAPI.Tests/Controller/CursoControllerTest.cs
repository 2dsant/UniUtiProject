using UniUti.Application.ValueObjects;
using UniUti.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UniUti.Controllers;
using Xunit;
using Moq;

namespace UniUti.Test.WebAPI.Tests.Controller
{
    public class CursoControllerTest
    {
        private readonly Mock<ICursoService> _serviceMock;
        private readonly CursoController _controller;

        public CursoControllerTest()
        {
            _serviceMock = new Mock<ICursoService>();
            _controller = new CursoController(_serviceMock.Object);
        }

        [Fact]
        public async Task Find_all_should_return_all_cursos()
        {
            //Arrange
            var cursos = new List<CursoResponseVO>()
            {
                new CursoResponseVO()
                {
                    Id = 1,
                    Nome = "Curso teste 01",
                },
                new CursoResponseVO()
                {
                    Id = 2,
                    Nome = "Curso teste 02",
                },
                new CursoResponseVO()
                {
                    Id = 2,
                    Nome = "Curso teste 03",
                }
            };

            //Action
            _serviceMock.Setup(x => x.FindAll()).ReturnsAsync(cursos);
            var actionResult = await _controller.FindAll();
            var result = actionResult.Result as OkObjectResult;

            //Assert
            Assert.NotNull(result.Value);
            Assert.True(result.StatusCode == 200);
        }

        [Fact]
        public async Task Find_all_should_return_not_found()
        {
            //Arrange
            var cursos = new List<CursoResponseVO>();

            //Action
            _serviceMock.Setup(x => x.FindAll()).ReturnsAsync(cursos);
            var actionResult = await _controller.FindAll();
            var result = actionResult.Result as NotFoundObjectResult;

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Find_all_should_return_bad_request()
        {
            //Arrange

            //Action
            _serviceMock.Setup(x => x.FindAll()).ThrowsAsync(new Exception());
            var actionResult = await _controller.FindAll();
            var result = actionResult.Result as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Find_by_id_should_return_a_curso()
        {
            //Arrange
            var curso = new CursoResponseVO()
                {
                    Id = 1,
                    Nome = "Curso teste 01",
                };

            //Action
            _serviceMock.Setup(x => x.FindById(It.IsAny<long>())).ReturnsAsync(curso);
            var actionResult = await _controller.FindById(It.IsAny<long>());
            var result = actionResult.Result as OkObjectResult;

            //Assert
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task Find_by_id_should_return_not_found()
        {
            //Arrange
            var curso = new CursoResponseVO();

            //Action
            _serviceMock.Setup(x => x.FindById(It.IsAny<long>())).ReturnsAsync(curso);
            var actionResult = await _controller.FindById(It.IsAny<long>());
            var result = actionResult.Result as NotFoundResult;

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Find_by_id_should_return_bad_request()
        {
            //Arrange

            //Action
            _serviceMock.Setup(x => x.FindById(It.IsAny<long>())).ThrowsAsync(new Exception());
            var actionResult = await _controller.FindById(It.IsAny<long>());
            var result = actionResult.Result as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create_should_success()
        {
            //Arrange

            //Action
            _serviceMock.Setup(x => x.Create(It.IsAny<CursoCreateVO>())).Verifiable();
            var actionResult = await _controller.Create(It.IsAny<CursoCreateVO>());

            //Assert
            _serviceMock.Verify(x => x.Create(It.IsAny<CursoCreateVO>()), Times.Once);
        }

        [Fact]
        public async Task Create_should_return_bad_request()
        {
            //Arrange

            //Action
            _serviceMock.Setup(x => x.Create(It.IsAny<CursoCreateVO>())).ThrowsAsync(new Exception());
            var actionResult = await _controller.Create(It.IsAny<CursoCreateVO>());
            var result = actionResult.Result as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create_should_return_bad_request_invalid_model()
        {
            //Arrange
            var curso = new CursoCreateVO()
            {
                Nome = "tes",
            };
            _controller.ModelState.AddModelError("teste", "teste");

            //Action
            _serviceMock.Setup(x => x.Create(curso)).Verifiable();
            var actionResult = await _controller.Create(curso);
            var result = actionResult.Result as BadRequestObjectResult;

            //Assert
            _serviceMock.Verify(x => x.Create(It.IsAny<CursoCreateVO>()), Times.Never);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Update_should_success()
        {
            //Arrange

            //Action
            _serviceMock.Setup(x => x.Update(It.IsAny<CursoResponseVO>())).Verifiable();
            var actionResult = await _controller.Update(It.IsAny<CursoResponseVO>());

            //Assert
            _serviceMock.Verify(x => x.Update(It.IsAny<CursoResponseVO>()), Times.Once);
        }

        [Fact]
        public async Task Update_should_return_bad_request()
        {
            //Arrange

            //Action
            _serviceMock.Setup(x => x.Update(It.IsAny<CursoResponseVO>())).ThrowsAsync(new Exception());
            var actionResult = await _controller.Update(It.IsAny<CursoResponseVO>());
            var result = actionResult.Result as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Update_should_return_bad_request_invalid_model()
        {
            //Arrange
            var curso = new CursoResponseVO()
            {
                Id = 1,
                Nome = "tes",
            };
            _controller.ModelState.AddModelError("teste", "teste");

            //Action
            _serviceMock.Setup(x => x.Update(curso)).Verifiable();
            var actionResult = await _controller.Update(curso);
            var result = actionResult.Result as BadRequestObjectResult;

            //Assert
            _serviceMock.Verify(x => x.Update(It.IsAny<CursoResponseVO>()), Times.Never);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete_should_return_a_curso()
        {
            //Arrange

            //Action
            _serviceMock.Setup(x => x.Delete(It.IsAny<long>())).ReturnsAsync(true);
            var actionResult = await _controller.Delete(It.IsAny<long>());
            var result = actionResult.Result as OkObjectResult;

            //Assert
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task Delete_should_return_not_found()
        {
            //Arrange

            //Action
            _serviceMock.Setup(x => x.Delete(It.IsAny<long>())).ReturnsAsync(false);
            var actionResult = await _controller.Delete(It.IsAny<long>());
            var result = actionResult.Result as NotFoundResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete_should_return_bad_request()
        {
            //Arrange

            //Action
            _serviceMock.Setup(x => x.Delete(It.IsAny<long>())).ThrowsAsync(new Exception());
            var actionResult = await _controller.Delete(It.IsAny<long>());
            var result = actionResult.Result as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
        }
    }
}
