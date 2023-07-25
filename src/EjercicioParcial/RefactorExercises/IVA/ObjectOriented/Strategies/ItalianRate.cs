namespace RefactorExercises.VAT.ObjectOriented.Strategies
{
    internal class ItalianRate : ICalculateRate
    {
        public decimal Rate() => 0.22m;
    }
}
