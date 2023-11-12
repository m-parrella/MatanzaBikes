using MatanzaBikes.Model;
using MatanzaBikes.Controllers;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MatanzaBikes.Tests
{
    public class MarcasControllerTests
    {

        readonly MatanzaBikesContext _context;

        public MarcasControllerTests()
        {
            var options = new DbContextOptionsBuilder<MatanzaBikesContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new MatanzaBikesContext(options);
            _context.Marcas.Add(
                new Marca()
                {
                    Nombre = "Ducati"
                });
            _context.Marcas.Add(
                new Marca()
                {
                    Nombre = "Yamaha"
                });
            _context.SaveChangesAsync();
        }

        [Fact]
        public async void GetMarcas_Test()
        {
            //Arrange
            var controller = new MarcasController(_context);

            //Act
            var response = await controller.GetMarcas();

            //Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void PutMarca_Test()
        {
            //Arrange
            var mController = new MarcasController(_context);
            var RecordToChange = _context.Marcas.FirstOrDefault();
            RecordToChange.Nombre = "Honda";

            //Act
            var resp = await mController.PutMarca(RecordToChange.Id, RecordToChange);
            var respAsResult = (NoContentResult)resp;

            //Assert
            var RecordChanged = _context.Marcas.First(m => m.Id == RecordToChange.Id);
            Assert.Equal(204, respAsResult.StatusCode);
            Assert.Equal("Honda", RecordChanged.Nombre);
        }

        [Fact]
        public async void PostMarca_Test()
        {
            //Arrange
            var marca = new Marca()
            {
                Nombre = "Gilera",
            };
            var mController = new MarcasController(_context);

            //Act
            var resp = await mController.PostMarca(marca);
            var respValue = (CreatedAtActionResult)resp.Result;
            var respCln = (Marca)respValue.Value;

            //Assert
            Assert.Equal(201, respValue.StatusCode);
            Assert.Equal(marca.Nombre, respCln.Nombre);
        }

        [Fact]
        public async void DeleteMarca_Test()
        {
            //Arrange
            var mController = new MarcasController(_context);
            var RecordToDelete = _context.Marcas.FirstOrDefault();

            //Act
            var resp = await mController.DeleteMarca(RecordToDelete.Id);
            var respAsResult = (NoContentResult)resp;

            //Assert
            Assert.Equal(204, respAsResult.StatusCode);
            var RecordDeleted = _context.Marcas.FirstOrDefault(m => m.Id == RecordToDelete.Id);
            Assert.Null(RecordDeleted);
        }

    }
}