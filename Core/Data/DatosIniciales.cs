using System.Collections.Generic;
using LigaBetplay.Core.Models;

namespace LigaBetplay.Core.Data
{
    // Provee los 20 equipos oficiales de la Liga BetPlay Dimayor 2026
    public static class DatosIniciales
    {
        public static List<Equipo> ObtenerEquipos()
        {
            return new List<Equipo>
            {
                new Equipo("Atletico Nacional"),
                new Equipo("Deportivo Pasto"),
                new Equipo("Once Caldas"),
                new Equipo("Internacional de Bogota"),
                new Equipo("Millonarios"),
                new Equipo("America de Cali"),
                new Equipo("Deportes Tolima"),
                new Equipo("Atletico Bucaramanga"),
                new Equipo("Junior FC"),
                new Equipo("Deportivo Cali"),
                new Equipo("Aguilas Doradas"),
                new Equipo("Llaneros FC"),
                new Equipo("Independiente Santa Fe"),
                new Equipo("Fortaleza FC"),
                new Equipo("Independiente Medellin"),
                new Equipo("Jaguares de Cordoba"),
                new Equipo("Alianza Valledupar"),
                new Equipo("Boyaca Chico"),
                new Equipo("Cucuta Deportivo"),
                new Equipo("Deportivo Pereira"),
            };
        }
    }
}
