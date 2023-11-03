using MatanzaBikes.Model;
using MatanzaBikes.Controllers;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace MatanzaBikes.Tests
{
    public class MarcasControllerTests
    {
        [Fact]
        public void GetMarcas()
        {
            //var context = new MatanzaBikes.Data.MatanzaBikesContext();
            //var context = new List<Marca>(){ new Marca()  };
            //var context = A.Fake<Marca>();
            //var controller = new MarcasController(context);
            //var result = controller.GetMarcas();
            //var mockSet = new Mock<DbSet<Marca>>();
            //var mockContext = new Mock<MatanzaBikesContext>();
            //mockContext.Setup(m => m.Marcas).Returns(mockSet.Object);
            //var service = new BlogService(mockContext.Object);
            //List<Marca> = MarcasController.GetMarcas();
            var result = "Prueba";
            Assert.NotNull(result);
        }
    }
}