using EjercicioParcial.IVA.Modelo;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EjercicioParcial.Tests.IVA
{
    public abstract class CalculadoraIVATestsTemplate
    {
        protected abstract decimal CalcularIVA(Direccion address, Orden order);

        [TestMethod]
        public void ConDireccionItaliana_ParaCalculoIVA()
        {
            //Arrange
            var address = new Direccion("italia");
            var product = new Producto("Sillón", 1m, false);
            var order = new Orden(product, 1);

            //Act
            var vat = CalcularIVA(address, order);

            //Assert
            vat.Should().Be(0.22m);
        }

        [TestMethod]
        public void ConDireccionJaponesa_ParaCalculoIVA()
        {
            //Arrange
            var address = new Direccion("japon");
            var product = new Producto("Sillón", 1m, false);
            var order = new Orden(product, 1);

            //Act
            var vat = CalcularIVA(address, order);

            //Assert
            vat.Should().Be(0.08m);
        }

        [TestMethod]
        public void ConDireccionAlemanaParaCalculoIVA()
        {
            //Arrange
            var address = new Direccion("alemania");
            var product = new Producto("Sillón", 1m, false);
            var order = new Orden(product, 1);

            //Act
            var vat = CalcularIVA(address, order);

            //Assert
            vat.Should().Be(0.2m);
        }

        [TestMethod]
        public void ConDireccionAlemanaYConProductosParaCalculoIVA()
        {
            //Arrange
            var address = new Direccion("alemania");
            var product = new Producto("Arroz", 1m, true);
            var order = new Orden(product, 1);

            //Act
            var vat = CalcularIVA(address, order);

            //Assert
            vat.Should().Be(0.08m);
        }

        [TestMethod]
        public void ConDireccionUSA_CaliforniaParaCalculoIVA()
        {
            //Arrange
            var address = new DireccionUSA("california");
            var product = new Producto("Sillón", 1m, false);
            var order = new Orden(product, 1);

            //Act
            var vat = CalcularIVA(address, order);

            //Assert
            vat.Should().Be(0.1m);
        }

        [TestMethod]
        public void ConDireccionUSA_FloridaParaCalculoIVA()
        {
            //Arrange
            var address = new DireccionUSA("florida");
            var product = new Producto("Sillón", 1m, false);
            var order = new Orden(product, 1);

            //Act
            var vat = CalcularIVA(address, order);

            //Assert
            vat.Should().Be(0.0625m);
        }

        [TestMethod]
        public void ConDireccionUSA_NewYorkParaCalculoIVA()
        {
            //Arrange
            var address = new DireccionUSA("newyork");
            var product = new Producto("Sillón", 1m, false);
            var order = new Orden(product, 1);

            //Act
            var vat = CalcularIVA(address, order);

            //Assert
            vat.Should().Be(0.085m);
        }
    }
}
