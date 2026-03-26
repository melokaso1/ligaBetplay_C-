using System;
using LigaBetplay.Core.Data;
using LigaBetplay.Core.Services;
using LigaBetplay.Modules.Equipos;
using LigaBetplay.Modules.Partidos;
using LigaBetplay.Modules.Tabla;

namespace LigaBetplay.Core
{
    // Clase de verificacion manual del sistema
    public static class VerificacionSistema
    {
        public static void Ejecutar()
        {
            var contexto = new TorneoContext();
            var servicioRandom = new ServicioRandom();
            var servicioCalendario = new ServicioCalendario();
            var servicioEquipos = new ServicioEquipos(contexto);
            var servicioPartidos = new ServicioPartidos(contexto, servicioRandom);
            var servicioTabla = new ServicioTabla(contexto);

            // --- ESCENARIO 1: Cargar los 20 equipos y generar el fixture ---
            Console.WriteLine("=== ESCENARIO 1: Registro de equipos y generacion del fixture ===");

            foreach (var equipo in DatosIniciales.ObtenerEquipos())
                servicioEquipos.RegistrarEquipo(equipo.Nombre);

            // Probar duplicado
            servicioEquipos.RegistrarEquipo("Millonarios");

            Console.WriteLine($"\nTotal de equipos registrados: {contexto.Equipos.Count}");

            // Generar el calendario round-robin y almacenarlo en el contexto
            contexto.Fixture = servicioCalendario.GenerarFixture(contexto.Equipos);
            Console.WriteLine(
                $"Fixture generado: {contexto.Fixture.Count} fechas de 10 partidos cada una."
            );

            // --- ESCENARIO 2: Simular la Fecha 1 y mostrar tabla ---
            Console.WriteLine("\n=== ESCENARIO 2: Simulacion de la Fecha 1 ===");
            servicioPartidos.SimularFechaActual();
            servicioTabla.MostrarTabla();

            // --- ESCENARIO 3: Simular las Fechas 2 y 3 y verificar que la tabla avanza ---
            Console.WriteLine("\n=== ESCENARIO 3: Simular Fecha 2 y Fecha 3 ===");
            servicioPartidos.SimularFechaActual();
            servicioPartidos.SimularFechaActual();
            servicioTabla.MostrarTabla();

            Console.WriteLine($"\nPartidos simulados en total: {contexto.Partidos.Count}");
            Console.WriteLine($"Proxima fecha a simular: {contexto.FechaActual}");
            Console.WriteLine("=== VERIFICACION COMPLETADA ===");
        }
    }
}
