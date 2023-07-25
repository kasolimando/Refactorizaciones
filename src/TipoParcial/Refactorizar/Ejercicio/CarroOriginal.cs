using System.Linq;

namespace EjercicioParcial.Ejercicio
{
    public class Carro
    {
        private int _x;
        private int _y;
        private char _direccion;
        private readonly string _direccionesDisponibles = "NESW";
        private readonly string[] _obstaculos;
        private bool _obstaculoEncontrado;

        public Carro(int x, int y, char direccion, string[] obstaculos)
        {
            _x = x;
            _y = y;
            _direccion = direccion;
            _obstaculos = obstaculos;
        }
        
        public string ObtenerEstado()
        {
            return !_obstaculoEncontrado ? $"{_x}:{_y}:{_direccion}" : $"O:{_x}:{_y}:{_direccion}";
        }

        public void Ejecutar(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    switch (_direccion)
                    {
                        case 'E':
                            _obstaculoEncontrado = _obstaculos.Contains($"{_x + 1}:{_y}");
                            _x = _x < 9 && !_obstaculoEncontrado ? _x += 1 : _x;
                            break;
                        case 'S':
                            _obstaculoEncontrado = _obstaculos.Contains($"{_x}:{_y + 1}");
                             _y = _y < 9 && !_obstaculoEncontrado ? _y += 1 : _y;
                            break;
                        case 'W':
                            _obstaculoEncontrado = _obstaculos.Contains($"{_x - 1}:{_y}");
                             _x = _x > 0 && !_obstaculoEncontrado ? _x -= 1 : _x;
                            break;
                        case 'N':
                            _obstaculoEncontrado = _obstaculos.Contains($"{_x}:{_y - 1}");
                            _y = _y > 0 && !_obstaculoEncontrado ? _y -= 1 : _y;
                            break;
                    }
                }
                else if(command == 'L')
                {
                    var currentDirectionPosition = _direccionesDisponibles.IndexOf(_direccion);
                    if (currentDirectionPosition != 0)
                    {
                        _direccion = _direccionesDisponibles[currentDirectionPosition-1];
                    }
                    else
                    {
                        _direccion = _direccionesDisponibles[3];
                    }
                } else if (command == 'R')
                {
                    var currentDirectionPosition = _direccionesDisponibles.IndexOf(_direccion);
                    if (currentDirectionPosition != 3)
                    {
                        _direccion = _direccionesDisponibles[currentDirectionPosition+1];
                    }
                    else
                    {
                        _direccion = _direccionesDisponibles[0];
                    }
                }
            }
        }
    }
}