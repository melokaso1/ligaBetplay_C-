using System.Collections.Generic;
using LigaBetplay.Core.Models;

namespace LigaBetplay.Core.Data
{
    // Clase central que gestiona las listas en memoria compartidas por todos los modulos
    public class TorneoContext
    {
        // Lista de equipos registrados en el torneo
        public List<Equipo> Equipos { get; set; }

        // Historial de partidos simulados
        public List<Partido> Partidos { get; set; }

        // Calendario completo de 19 fechas generado por ServicioCalendario
        public List<Fecha> Fixture { get; set; }

        // Puntero a la proxima fecha a simular (inicia en 1)
        public int FechaActual { get; set; } = 1;

        // Inicializa las listas vacias al arrancar la aplicacion
        public TorneoContext()
        {
            Equipos = new List<Equipo>();
            Partidos = new List<Partido>();
            Fixture = new List<Fecha>();
        }
    }
}
