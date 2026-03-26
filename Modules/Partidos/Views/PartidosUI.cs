using System;
using LigaBetplay.Core;

namespace LigaBetplay.Modules.Partidos
{
    public class PartidosUI
    {
        public static void SimularFecha()
        {
            TorneoApp.Instance.Partidos.SimularFechaActual();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void VerHistorial()
        {
            var partidos = TorneoApp.Instance.Partidos.ListarPartidos();
            Console.WriteLine("\n--- Historial de Partidos Simulados ---");
            if (partidos.Count == 0)
            {
                Console.WriteLine("Aun no hay partidos simulados.");
            }
            else
            {
                var partidosPorFecha = System.Linq.Enumerable.OrderBy(
                    System.Linq.Enumerable.GroupBy(partidos, p => p.NumeroFecha),
                    g => g.Key
                );
                foreach (var fecha in partidosPorFecha)
                {
                    Console.WriteLine($"\n  === FECHA {fecha.Key} ===");
                    foreach (var p in fecha)
                    {
                        Console.WriteLine(
                            $"    {p.EquipoLocal.Nombre, -28} {p.GolesLocal} - {p.GolesVisitante, 1}  {p.EquipoVisitante.Nombre}"
                        );
                    }
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
