using LigaBetplay.Core.Models;

namespace LigaBetplay.Core.Models
{
    // Representa el resultado de un enfrentamiento entre dos equipos
    public class Partido
    {
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }

        public Partido(Equipo equipoLocal, Equipo equipoVisitante, int golesLocal, int golesVisitante)
        {
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            GolesLocal = golesLocal;
            GolesVisitante = golesVisitante;
        }
    }
}
