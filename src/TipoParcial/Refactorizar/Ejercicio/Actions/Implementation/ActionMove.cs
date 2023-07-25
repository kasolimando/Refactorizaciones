using EjercicioParcial.Ejercicio.Actions.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioParcial.Ejercicio.Actions.Implementation
{
    public class ActionMove : IActions
    {
        private Dictionary<char, Action<Carro>> movements = new Dictionary<char, Action<Carro>>()
        {
            {'E', MoveEast },
            {'S', MoveSouth },
            {'W', MoveWest },
            {'N', MoveNorth }
        };

        //Se realiza el movimiento dependiendo de la direccion indicada
        public void Move(Carro carro)
        {
            if (movements.TryGetValue(carro._direccion, out var movement))
            {
                movement(carro);
            }
        }

        //se hace el movimiento hacia East
        private static void MoveEast(Carro carro)
        {
            carro._obstaculoEncontrado = carro._obstaculos.Contains($"{carro._x + 1}:{carro._y}");
            carro._x = carro._x < 9 && !carro._obstaculoEncontrado ? carro._x + 1 : carro._x;
        }

        //se hace el movimiento hacia south
        private static void MoveSouth(Carro carro)
        {
            carro._obstaculoEncontrado = carro._obstaculos.Contains($"{carro._x}:{carro._y + 1}");
            carro._y = carro._y < 9 && !carro._obstaculoEncontrado ? carro._y + 1 : carro._y;
        }

        //se hace el movimiento hacia west
        private static void MoveWest(Carro carro)
        {
            carro._obstaculoEncontrado = carro._obstaculos.Contains($"{carro._x - 1}:{carro._y}");
            carro._x = carro._x > 0 && !carro._obstaculoEncontrado ? carro._x - 1 : carro._x;
        }

        //se hace el movimiento hacia North
        private static void MoveNorth(Carro carro)
        {
            carro._obstaculoEncontrado = carro._obstaculos.Contains($"{carro._x}:{carro._y - 1}");
            carro._y = carro._y > 0 && !carro._obstaculoEncontrado ? carro._y - 1 : carro._y;
        }
    }
}
