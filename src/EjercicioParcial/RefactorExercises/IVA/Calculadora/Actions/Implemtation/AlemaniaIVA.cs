using EjercicioParcial.IVA.Modelo;
using EjercicioParcial.IVA.Calculadora.Actions.Interfaz;

namespace EjercicioParcial.IVA.Calculadora.Actions.Implementation
{
    public class AlemaniaIVA : ICountryIVA
    {
        private const decimal TasaComida = 0.08m;
        private const decimal TasaGeneral = 0.2m;

        // Método para obtener el IVA basado en la dirección y la orden
        public decimal GetIVA(Direccion direccion, Orden orden)
        {
            decimal tasaIVA = orden.producto.esComida ? TasaComida : TasaGeneral;
            return orden.PrecioNeto * tasaIVA;
        }
    }
}
