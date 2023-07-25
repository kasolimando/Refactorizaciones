

using EjercicioParcial.Ejercicio.Actions.Implementation;
using EjercicioParcial.Ejercicio.Mediator.Implementation;
using EjercicioParcial.Ejercicio.Mediator.Interfaz;

namespace EjercicioParcial.Ejercicio
{
    public class Carro
    {
        internal int _x;
        internal int _y;
        internal char _direccion;
        internal readonly string _direccionesDisponibles = "NESW";
        internal readonly string[] _obstaculos;
        internal bool _obstaculoEncontrado;
        private IMediator _mediator;

        public Carro(int x, int y, char direccion, string[] obstaculos)
        {
            _x = x;
            _y = y;
            _direccion = direccion;
            _obstaculos = obstaculos;

            //Se crea el mediator y se agregan las acciones
            _mediator = new Mediatr();
            _mediator.AddAccion('M', new ActionMove());
            _mediator.AddAccion('L', new ActionLeft());
            _mediator.AddAccion('R', new ActionRight());
        }

        //Se obtiene el estado con las variables x, y y la direccion 
        public string ObtenerEstado()
        {
            var obstaculo = _obstaculoEncontrado ? "O:" : "";
            return $"{obstaculo}{_x}:{_y}:{_direccion}";
        }

        //se ejecuta la accion a traves del command
        public void Ejecutar(string commands)
        {
            foreach (char command in commands)
            {
                _mediator.Notificar(command, this);
            }
        }
    }
}