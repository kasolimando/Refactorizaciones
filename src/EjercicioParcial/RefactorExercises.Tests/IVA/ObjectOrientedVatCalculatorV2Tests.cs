using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorExercises.VAT.Model;
using ObjectOrientedOrder = RefactorExercises.VAT.ObjectOriented.V2.Order;

namespace RefactorExercises.Tests.VAT
{
    [TestClass]
    public class ObjectOrientedVatCalculatorV2Tests : VatCalculatorTestsTemplate
    {
        protected override decimal CalculateVat(Address address, Order order)
        {
            var orderV2 = new ObjectOrientedOrder(order);
            return orderV2.Vat(address);
        }
    }
}
