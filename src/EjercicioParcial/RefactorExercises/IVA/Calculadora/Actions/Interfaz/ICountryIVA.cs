using EjercicioParcial.IVA.Modelo;

namespace EjercicioParcial.IVA.Calculadora.Actions.Interfaz
{
    public interface ICountryIVA
    {
        decimal GetIVA(Direccion direccion, Orden orden);
    }
}
