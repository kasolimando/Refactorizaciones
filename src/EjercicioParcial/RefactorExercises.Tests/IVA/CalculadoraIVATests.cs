using EjercicioParcial.IVA.Calculadora;
using EjercicioParcial.IVA.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EjercicioParcial.Tests.IVA
{
    [TestClass]
    public class FunctionalIVACalculatorTests : CalculadoraIVATestsTemplate
    {
        protected override decimal CalcularIVA(Direccion address, Orden order)
        {
            return CalculadoraIVA.IVA(address, order);
        }
    }
}
