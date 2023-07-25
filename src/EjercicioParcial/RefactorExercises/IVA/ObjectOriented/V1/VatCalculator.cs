using RefactorExercises.VAT.Model;
using RefactorExercises.VAT.ObjectOriented.Strategies;
using System;

namespace RefactorExercises.VAT.ObjectOriented.V1
{
    public class VatCalculator
    {
        private readonly Address _address;
        private readonly Order _order;

        public VatCalculator(Address address, Order order)
        {
            _address = address;
            _order = order;
        }

        public decimal Vat()
        {
            return _address.Country switch
            {
                "it" => Vat(new ItalianRate()),
                "jp" => Vat(new JapaneseRate()),
                "de" => Vat(new GermanRate(_order.Product)),
                "us" => Vat(new UsRate(_address as UsAddress)),
                _ => throw new ArgumentException($"Missing rate for {_address.Country}")
            };
        }

        private decimal Vat(ICalculateRate rateStrategy)
        {
            return _order.NetPrice * rateStrategy.Rate();
        }
    }
}
