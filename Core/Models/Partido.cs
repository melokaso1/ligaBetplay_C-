using LigaBetplay.Core.Models;

namespace LigaBetplay.Core.Models
{
    // Representa un enfrentamiento entre dos equipos en una fecha del torneo
    public class Partido
    {
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }

        // Jornada a la que pertenece este partido
        public int NumeroFecha { get; set; }

        // Dia dentro de la jornada en que se juega (1, 2 o 3)
        public int Dia { get; set; }

        public Partido(Equipo equipoLocal, Equipo equipoVisitante, int numeroFecha, int dia)
        {
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            NumeroFecha = numeroFecha;
            Dia = dia;
        }
    }
}

