using MatanzaBikes.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatanzaBikes.Tests
{
    public class MotosControllerTests
    {
        readonly MatanzaBikesContext _context;

        public MotosControllerTests()
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
            _context.Motos.Add(
                new Moto()
                {
                    MarcaId = 1,
                    Modelo = "Fake",
                    Cilindrada = "650 cc",
                    Color = "Verde",
                    Año = 2023,
                    Motor = "4 tiempos",
                    Bateria = "12",
                    Peso = 250,
                    Rodado = 118,
                    Suspension = "Hidraulica",
                    Frenos = "Disco",
                    Stock = 57,
                    Precio = 100
                });
             _context.SaveChangesAsync();
        }

        [Fact]
        public async void GetMotos_Test()
        {
            //Arrange
            var controller = new MotosController(_context);

            //Act
            var response = await controller.GetMotos();

            //Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void PutMoto_Test()
        {
            //Arrange
            var mController = new MotosController(_context);
            var RecordToChange = _context.Motos.FirstOrDefault();
            RecordToChange.Color = "Rojo";

            //Act
            var resp = await mController.PutMoto(RecordToChange.Id, RecordToChange);
            var respAsResult = (NoContentResult)resp;

            //Assert
            var RecordChanged = _context.Motos.First(m => m.Id == RecordToChange.Id);
            Assert.Equal(204, respAsResult.StatusCode);
            Assert.Equal("Rojo", RecordChanged.Color);
        }

        [Fact]
        public async void PostMoto_Test()
        {
            //Arrange
            var moto = new Moto()
            {
                MarcaId = 1,
                Modelo = "New Fake",
                Cilindrada = "650 cc",
                Color = "Verde",
                Año = 2023,
                Motor = "4 tiempos",
                Bateria = "12",
                Peso = 250,
                Rodado = 118,
                Suspension = "Hidraulica",
                Frenos = "Disco",
                Stock = 57,
                Precio = 100
            };
            var mController = new MotosController(_context);

            //Act
            var resp = await mController.PostMoto(moto);
            var respValue = (CreatedAtActionResult)resp.Result;
            var respCln = (Moto)respValue.Value;

            //Assert
            Assert.Equal(201, respValue.StatusCode);
            Assert.Equal(moto.Color, respCln.Color);
        }

        [Fact]
        public async void DeleteMoto_Test()
        {
            //Arrange
            var mController = new MotosController(_context);
            var RecordToDelete = _context.Motos.FirstOrDefault();

            //Act
            var resp = await mController.DeleteMoto(RecordToDelete.Id);
            var respAsResult = (NoContentResult)resp;

            //Assert
            Assert.Equal(204, respAsResult.StatusCode);
            var RecordDeleted = _context.Motos.FirstOrDefault(m => m.Id == RecordToDelete.Id);
            Assert.Null(RecordDeleted);
        }
    }
}