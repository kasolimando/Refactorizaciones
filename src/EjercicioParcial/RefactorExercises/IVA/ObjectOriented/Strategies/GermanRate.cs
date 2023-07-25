using RefactorExercises.VAT.Model;

namespace RefactorExercises.VAT.ObjectOriented.Strategies
{
    internal class GermanRate : ICalculateRate
    {
        private readonly Product _product;

        public GermanRate(Product product)
        {
            _product = product;
        }

        public decimal Rate()
        {
            if (_product.IsFood)
            {
                return 0.08m;
            }

            return 0.2m;
        }
    }
}
