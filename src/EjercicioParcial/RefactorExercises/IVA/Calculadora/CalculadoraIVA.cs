using EjercicioParcial.IVA.Modelo;
using System;
using EjercicioParcial.IVA.Calculadora.Actions.Interfaz;
using EjercicioParcial.IVA.Calculadora.Actions.Implementation;
using System.Collections.Generic;

namespace EjercicioParcial.IVA.Calculadora
{
    public static class CalculadoraIVA
    {
        // Diccionario que asocia un país con una instancia de una clase que implementa la interfaz ICountryIVA
        private static readonly Dictionary<string, ICountryIVA> AccionesPorDireccion = new Dictionary<string, ICountryIVA>()
        {
            { "alemania", new AlemaniaIVA() },
            { "usa", new UsaIVA() },
            { "italia", new ItaliaIVA() },
            { "japon",new JaponIVA() },
        };

        // Función para calcular el IVA basado en la dirección y la orden
        public static decimal IVA(Direccion direccion, Orden orden)
        {
            if (AccionesPorDireccion.TryGetValue(direccion.Pais, out ICountryIVA countryIVA))
            {
                return countryIVA.GetIVA(direccion, orden);
            }
            else
            {
                throw new ArgumentException($"Perdida de la tarifa para {direccion.Pais}");
            }
        }
    }
}
