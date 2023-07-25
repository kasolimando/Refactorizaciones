namespace RefactorExercises.VAT.ObjectOriented.Strategies
{
    internal class JapaneseRate : ICalculateRate
    {
        public decimal Rate() => 0.08m;
    }
}
