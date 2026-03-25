namespace LigaBetplay.Core.Models
{
    // Representa un equipo participante en el torneo con sus estadisticas
    public class Equipo
    {
        // Nombre del equipo
        public string Nombre { get; set; }

        // Partidos Jugados
        public int PJ { get; set; } = 0;

        // Partidos Ganados
        public int PG { get; set; } = 0;

        // Partidos Empatados
        public int PE { get; set; } = 0;

        // Partidos Perdidos
        public int PP { get; set; } = 0;

        // Goles a Favor
        public int GF { get; set; } = 0;

        // Goles en Contra
        public int GC { get; set; } = 0;

        // Diferencia de Gol (calculada)
        public int DG => GF - GC;

        // Total de Puntos (calculado: 3 por victoria, 1 por empate)
        public int TP => (PG * 3) + PE;

        // Solo el nombre es requerido; las estadisticas inician en cero
        public Equipo(string nombre)
        {
            Nombre = nombre;
        }
    }
}
