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
            var result = "Prueba";
            Assert.NotNull(result);
        }
    }
}