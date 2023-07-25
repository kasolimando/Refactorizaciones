using Xunit;

namespace EjercicioParcial.Ejercicio.Tests
{
    public class CarroTest
    {
        [Fact]
        public void AceptarUnEstadoInicial()
        {
            Carro carro = new Carro(0, 0, 'E', new string[] { });

            Assert.Equal("0:0:E", carro.ObtenerEstado());
        }

        [Theory]
        [InlineData(0, 0, 'E', "M", "1:0:E")]
        [InlineData(0, 0, 'S', "M", "0:1:S")]
        [InlineData(1, 0, 'W', "M", "0:0:W")]
        [InlineData(0, 1, 'N', "M", "0:0:N")]
        public void MoverUnaCeldaHaciaAdelante(int x, int y, char direction, string commands, string expectedFinalState)
        {
            Carro carro = new Carro(x, y, direction, new string[] { });

            carro.Ejecutar(commands);

            Assert.Equal(expectedFinalState, carro.ObtenerEstado());
        }
        
        [Theory]
        [InlineData(0, 0, 'N', "M", "0:0:N")]
        [InlineData(0, 0, 'W', "M", "0:0:W")]
        [InlineData(9, 0, 'E', "M", "9:0:E")]
        [InlineData(0, 9, 'S', "M", "0:9:S")]
        public void RodeaLosAngulosDeLaPlataforma(int x, int y, char direction, string commands, string expectedFinalState)
        {
            Carro carro = new Carro(x, y, direction, new string[] { });

            carro.Ejecutar(commands);

            Assert.Equal(expectedFinalState, carro.ObtenerEstado());
        }
        
        [Theory]
        [InlineData("L", "0:0:N")]
        [InlineData("LL", "0:0:W")]
        [InlineData("LLL", "0:0:S")]
        [InlineData("LLLL", "0:0:E")]
        [InlineData("R", "0:0:S")]
        [InlineData("RR", "0:0:W")]
        [InlineData("RRR", "0:0:N")]
        [InlineData("RRRR", "0:0:E")]
        public void RotarIzquierdaYDerecha(string commands, string expectedFinalState)
        {
            Carro marsRover = new Carro(0, 0, 'E', new string[] { });

            marsRover.Ejecutar(commands);

            Assert.Equal(expectedFinalState, marsRover.ObtenerEstado());
        }

        [Theory]
        [InlineData(0, 0, 'E', "MMM", new[] { "3:0" }, "O:2:0:E")]
        [InlineData(0, 0, 'S', "MMM", new[] { "0:3" }, "O:0:2:S")]
        [InlineData(9, 0, 'W', "MMM", new[] { "7:0" }, "O:8:0:W")]
        [InlineData(0, 9, 'N', "MMM", new[] { "0:7" }, "O:0:8:N")]
        public void DetenerseYReportarSiUnObstaculoFueEncontrado(int x, int y, char direction, string commands, string[] obstacles, string expectedFinalState)
        {
            Carro marsRover = new Carro(x, y, direction, obstacles);

            marsRover.Ejecutar(commands);

            Assert.Equal(expectedFinalState, marsRover.ObtenerEstado());            
        }
    }
}