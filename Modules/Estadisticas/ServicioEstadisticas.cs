using System;
using System.Collections.Generic;
using System.Linq;
using LigaBetplay.Core.Data;
using LigaBetplay.Core.Models;

namespace LigaBetplay.Modules.Estadisticas
{
    // Servicio que calcula y muestra estadisticas generales del torneo
    public class ServicioEstadisticas
    {
        private readonly TorneoContext _contexto;

        public ServicioEstadisticas(TorneoContext contexto)
        {
            _contexto = contexto;
        }

        // Muestra todas las estadisticas destacadas del torneo
        public void MostrarEstadisticas()
        {
            var equipos = _contexto.Equipos.Where(e => e.PJ > 0).ToList();

            if (!equipos.Any())
            {
                Console.WriteLine("\n  No hay partidos simulados aun. Simula al menos una fecha primero.");
                return;
            }

            // Lider actual
            var lider = equipos.OrderByDescending(e => e.TP).ThenByDescending(e => e.DG).First();
            Console.WriteLine($"\n  Lider actual              : {lider.Nombre} — {lider.TP} pts | DG: {lider.DG}");

            // Equipo mas goleador (mas GF)
            var masGoleador = equipos.OrderByDescending(e => e.GF).First();
            Console.WriteLine($"  Equipo mas goleador       : {masGoleador.Nombre} — {masGoleador.GF} goles a favor");

            // Equipo menos goleador en contra (mejor defensa)
            var mejorDefensa = equipos.OrderBy(e => e.GC).First();
            Console.WriteLine($"  Mejor defensa (menos GC)  : {mejorDefensa.Nombre} — {mejorDefensa.GC} goles en contra");

            // Equipo mas ganador
            var masGanador = equipos.OrderByDescending(e => e.PG).First();
            Console.WriteLine($"  Equipo mas ganador        : {masGanador.Nombre} — {masGanador.PG} victorias");

            // Equipo mas perdedor
            var masPerdedor = equipos.OrderByDescending(e => e.PP).First();
            Console.WriteLine($"  Equipo mas perdedor       : {masPerdedor.Nombre} — {masPerdedor.PP} derrotas");

            // Mejor constancia: mayor ratio victorias / partidos jugados
            var mejorConstancia = equipos.OrderByDescending(e => (double)e.PG / e.PJ).First();
            Console.WriteLine($"  Mejor constancia          : {mejorConstancia.Nombre} — {(double)mejorConstancia.PG / mejorConstancia.PJ:P0} de victorias");

            // Peor constancia: mayor ratio derrotas / partidos jugados
            var peorConstancia = equipos.OrderByDescending(e => (double)e.PP / e.PJ).First();
            Console.WriteLine($"  Peor constancia           : {peorConstancia.Nombre} — {(double)peorConstancia.PP / peorConstancia.PJ:P0} de derrotas");

            // Equipos invictos (sin derrotas)
            var invictos = equipos.Where(e => e.PP == 0).ToList();
            Console.WriteLine($"\n  Equipos invictos          : {(invictos.Any() ? string.Join(", ", invictos.Select(e => e.Nombre)) : "Ninguno")}");

            // Equipos sin victorias
            var sinVictoria = equipos.Where(e => e.PG == 0).ToList();
            Console.WriteLine($"  Equipos sin victoria      : {(sinVictoria.Any() ? string.Join(", ", sinVictoria.Select(e => e.Nombre)) : "Ninguno")}");

            // Promedios y totales globales
            int totalFechas = _contexto.Fixture.Count;
            Console.WriteLine($"\n  Promedio goles a favor    : {equipos.Average(e => e.GF):F2}");
            Console.WriteLine($"  Promedio goles en contra  : {equipos.Average(e => e.GC):F2}");
            Console.WriteLine($"  Total goles en el torneo  : {equipos.Sum(e => e.GF)}");
            Console.WriteLine($"  Total partidos jugados    : {_contexto.Partidos.Count}");
            Console.WriteLine($"  Fechas simuladas          : {_contexto.FechaActual - 1} de {totalFechas}");
        }
    }
}
