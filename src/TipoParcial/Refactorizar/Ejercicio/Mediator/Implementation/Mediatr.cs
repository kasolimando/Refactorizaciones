using EjercicioParcial.Ejercicio.Actions.Interfaz;
using EjercicioParcial.Ejercicio.Mediator.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioParcial.Ejercicio.Mediator.Implementation
{
    public class Mediatr : IMediator
    {
        private Dictionary<char, IActions> _acciones;

        //Se crea el diccionario que tendrá las acciones
        public Mediatr()
        {
            _acciones = new Dictionary<char, IActions>();
        }

        //se agregan las acciones al diccionario
        public void AddAccion(char comando, IActions accion)
        {
            _acciones.Add(comando, accion);
        }

        //Se realiza la accion dependiendo del commando
        public void Notificar(char comando, Carro carro)
        {
            if (_acciones.TryGetValue(comando, out IActions accion))
            {
                accion.Move(carro);
            }
        }
    }
}
