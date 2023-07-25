using EjercicioParcial.IVA.Modelo;
using System;

namespace EjercicioParcial.IVA.Calculadora
{
    public static class CalculadoraIVA
    {
        public static decimal IVA(Direccion direccion, Orden orden)
            => direccion switch
            {
                DireccionUSA(var estado) => IVA(TasaPorEstado(estado), orden),
                ("alemania") _ => DeIVA(orden),
                (var country) _ => IVA(TasaPorPais(direccion.Pais), orden)
            };

        static decimal DeIVA(Orden order)
            => order.PrecioNeto * (order.producto.esComida ? 0.08m : 0.2m);

        static decimal TasaPorPais(string pais)
            => pais switch
            {
                "italia" => 0.22m,
                "japon" => 0.08m,
                _ => throw new ArgumentException($"Perdida de la tarifa para {pais}")
            };

        static decimal TasaPorEstado(string estado)
            => estado switch
            {
                "california" => 0.1m,
                "florida" => 0.0625m,
                "newyork" => 0.085m,
                _ => throw new ArgumentException($"Perdida de la tarifa para {estado}")
            };

        static decimal IVA(decimal tarifa, Orden orden)
            => orden.PrecioNeto * tarifa;
    }
}
