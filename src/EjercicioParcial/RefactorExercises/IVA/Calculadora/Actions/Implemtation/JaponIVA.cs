using EjercicioParcial.IVA.Modelo;
using EjercicioParcial.IVA.Calculadora.Actions.Interfaz;

namespace EjercicioParcial.IVA.Calculadora.Actions.Implementation
{
    public class JaponIVA : ICountryIVA
    {
        private const decimal tarifa = 0.08m;

        // Método para obtener el IVA basado en la dirección y la orden
        public decimal GetIVA(Direccion direccion, Orden orden)
        {
            return orden.PrecioNeto* tarifa;
        }
    }
}
