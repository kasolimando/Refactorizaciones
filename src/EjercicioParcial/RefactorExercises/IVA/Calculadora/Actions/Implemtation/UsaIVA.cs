using EjercicioParcial.IVA.Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EjercicioParcial.IVA.Calculadora.Actions.Interfaz;

namespace EjercicioParcial.IVA.Calculadora.Actions.Implementation
{
    public class UsaIVA : ICountryIVA
    {
        // Diccionario que asocia cada estado con su tarifa de IVA correspondiente
        private readonly Dictionary<string, decimal> tarifasPorEstado = new Dictionary<string, decimal>()
        {
            { "california", 0.1m },
            { "florida", 0.0625m },
            { "newyork", 0.085m }
        };

        // Método para obtener el IVA basado en la dirección y la orden
        public decimal GetIVA(Direccion direccion, Orden orden)
        {
            if (direccion is DireccionUSA direccionUSA)
            {
                // Si la dirección es de Estados Unidos, se verifica si existe una tarifa de IVA para el estado correspondiente
                if (tarifasPorEstado.TryGetValue(direccionUSA.Estado, out decimal tasa))
                {
                    return orden.PrecioNeto * tasa;
                }
                else
                {
                    throw new ArgumentException($"Perdida de la tarifa para {direccionUSA.Estado}");
                }
            }
            throw new ArgumentException($"Perdida de la tarifa para {direccion.Pais}");
        }
    }
}
