using System.Collections.Generic;

namespace LigaBetplay.Core.Models
{
    // Representa una jornada del torneo con sus 10 partidos
    public class Fecha
    {
        // Numero de jornada (1 a 19)
        public int Numero { get; set; }

        // Los 10 partidos que se juegan en esta jornada
        public List<Partido> Partidos { get; set; }

        // Indica si esta fecha ya fue simulada
        public bool Simulada { get; set; } = false;

        public Fecha(int numero)
        {
            Numero = numero;
            Partidos = new List<Partido>();
        }
    }
}
