using System;

namespace LigaBetplay.Core.Services
{
    // Servicio de utilidad para generar valores aleatorios en la simulacion
    public class ServicioRandom
    {
        // Instancia unica de Random para evitar repeticion de valores
        private readonly Random _random;

        public ServicioRandom()
        {
            _random = new Random();
        }

        // Retorna un numero de goles aleatorio entre 0 y 5 (rango estandar)
        public int NextGoles()
        {
            return _random.Next(0, 6);
        }


    }
}
