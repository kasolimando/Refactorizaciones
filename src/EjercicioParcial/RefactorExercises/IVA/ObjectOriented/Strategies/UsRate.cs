using RefactorExercises.VAT.Model;
using System;

namespace RefactorExercises.VAT.ObjectOriented.Strategies
{
    internal class UsRate : ICalculateRate
    {
        private readonly string _state;

        public UsRate(UsAddress usAddress)
        {
            _state = usAddress?.State ?? throw new ArgumentException($"Cannot find State information for US address");
        }

        public decimal Rate()
        {
            return _state switch
            {
                "ca" => 0.1m,
                "ma" => 0.0625m,
                "ny" => 0.085m,
                _ => throw new ArgumentException($"Missing rate for {_state}"),
            };
        }
    }
}
