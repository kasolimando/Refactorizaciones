using EjercicioParcial.Ejercicio.Actions.Interfaz;


namespace EjercicioParcial.Ejercicio.Actions.Implementation
{
    public class ActionRight : IActions
    {
        //Se realiza el movimiento right
        public void Move(Carro carro)
        {
            var currentDirectionPosition = carro._direccionesDisponibles.IndexOf(carro._direccion);
            if (currentDirectionPosition != 3)
            {
                carro._direccion = carro._direccionesDisponibles[currentDirectionPosition + 1];
            }
            else
            {
                carro._direccion = carro._direccionesDisponibles[0];
            }
        }
    }
}
