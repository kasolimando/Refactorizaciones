using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorExercises.VAT.Model;
using RefactorExercises.VAT.ObjectOriented.V1;

namespace RefactorExercises.Tests.VAT
{
    [TestClass]
    public class ObjectOrientedVatCalculatorV1Tests : VatCalculatorTestsTemplate
    {
        protected override decimal CalculateVat(Address address, Order order)
        {
            var calculator = new VatCalculator(address, order);
            return calculator.Vat();
        }
    }
}
