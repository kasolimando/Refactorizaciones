using EjercicioParcial.Ejercicio.Actions.Interfaz;


namespace EjercicioParcial.Ejercicio.Mediator.Interfaz
{
    public interface IMediator
    {
        void AddAccion(char comando, IActions accion);
        void Notificar(char comando, Carro carro);
    }
}
