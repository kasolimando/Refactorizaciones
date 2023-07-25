using RefactorExercises.VAT.Model;
using RefactorExercises.VAT.ObjectOriented.Strategies;
using System;
using ModelOrder = RefactorExercises.VAT.Model.Order;

namespace RefactorExercises.VAT.ObjectOriented.V2
{
    public class Order
    {
        public Order()
        {

        }

        public Order(ModelOrder o)
        {
            Product = o.Product;
            Quantity = o.Quantity;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal NetPrice => Product.Price * Quantity;

        public decimal Vat(Address address)
        {
            return address.Country switch
            {
                "it" => Vat(new ItalianRate()),
                "jp" => Vat(new JapaneseRate()),
                "de" => Vat(new GermanRate(Product)),
                "us" => Vat(new UsRate(address as UsAddress)),
                _ => throw new ArgumentException($"Missing rate for {address.Country}")
            };
        }

        private decimal Vat(ICalculateRate rateStrategy)
        {
            return NetPrice * rateStrategy.Rate();
        }
    }
}
