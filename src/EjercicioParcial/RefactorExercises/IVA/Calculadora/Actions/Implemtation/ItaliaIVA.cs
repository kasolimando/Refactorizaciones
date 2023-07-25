using EjercicioParcial.IVA.Modelo;
using EjercicioParcial.IVA.Calculadora.Actions.Interfaz;

namespace EjercicioParcial.IVA.Calculadora.Actions.Implementation
{
    public class ItaliaIVA : ICountryIVA
    {
        private const decimal tarifa = 0.22m;

        // Método para obtener el IVA basado en la dirección y la orden
        public decimal GetIVA(Direccion direccion, Orden orden)
        {
            return orden.PrecioNeto* tarifa;
        }
    }
}
