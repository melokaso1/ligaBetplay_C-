using System;
using LigaBetplay.Core.Data;
using LigaBetplay.Core.Services;
using LigaBetplay.Modules.Equipos;
using LigaBetplay.Modules.Partidos;

namespace LigaBetplay.Core
{
    // Clase de verificacion manual del sistema — sin frameworks de testing
    public static class VerificacionSistema
    {
        public static void Ejecutar()
        {
            var contexto = new TorneoContext();
            var servicioRandom = new ServicioRandom();
            var servicioEquipos = new ServicioEquipos(contexto);
            var servicioPartidos = new ServicioPartidos(contexto, servicioRandom);

            // --- ESCENARIO 1: Registrar equipos y verificar la lista ---
            Console.WriteLine("=== ESCENARIO 1: Registro de equipos ===");

            servicioEquipos.RegistrarEquipo("Atletico Nacional");
            servicioEquipos.RegistrarEquipo("Millonarios");
            servicioEquipos.RegistrarEquipo("America de Cali");
            servicioEquipos.RegistrarEquipo("Millonarios"); // duplicado, debe avisarse

            var equipos = servicioEquipos.ListarEquipos();
            Console.WriteLine($"Total de equipos registrados: {equipos.Count}");
            foreach (var e in equipos)
                Console.WriteLine($"  - {e.Nombre}");

            // --- ESCENARIO 2: Simular un partido y verificar estadisticas ---
            Console.WriteLine("\n=== ESCENARIO 2: Estadisticas antes y despues del partido ===");

            var local = equipos[0];
            var visitante = equipos[1];

            Console.WriteLine($"\n[ANTES] {local.Nombre}: PJ={local.PJ} PG={local.PG} PE={local.PE} PP={local.PP} GF={local.GF} GC={local.GC} DG={local.DG} TP={local.TP}");
            Console.WriteLine($"[ANTES] {visitante.Nombre}: PJ={visitante.PJ} PG={visitante.PG} PE={visitante.PE} PP={visitante.PP} GF={visitante.GF} GC={visitante.GC} DG={visitante.DG} TP={visitante.TP}");

            Console.WriteLine("\nSimulando partido...");
            servicioPartidos.SimularPartido(local, visitante);

            Console.WriteLine($"\n[DESPUES] {local.Nombre}: PJ={local.PJ} PG={local.PG} PE={local.PE} PP={local.PP} GF={local.GF} GC={local.GC} DG={local.DG} TP={local.TP}");
            Console.WriteLine($"[DESPUES] {visitante.Nombre}: PJ={visitante.PJ} PG={visitante.PG} PE={visitante.PE} PP={visitante.PP} GF={visitante.GF} GC={visitante.GC} DG={visitante.DG} TP={visitante.TP}");

            // --- ESCENARIO 3: Simular mas partidos y listar historial ---
            Console.WriteLine("\n=== ESCENARIO 3: Historial de partidos ===");

            servicioPartidos.SimularPartido(equipos[0], equipos[2]);
            servicioPartidos.SimularPartido(equipos[1], equipos[2]);

            var partidos = servicioPartidos.ListarPartidos();
            Console.WriteLine($"\nTotal de partidos simulados: {partidos.Count}");
            Console.WriteLine("Historial:");
            foreach (var p in partidos)
                Console.WriteLine($"  {p.EquipoLocal.Nombre} {p.GolesLocal} - {p.GolesVisitante} {p.EquipoVisitante.Nombre}");

            Console.WriteLine("\n=== VERIFICACION COMPLETADA ===");
        }
    }
}
