using System;
using LigaBetplay.Core.Data;
using LigaBetplay.Core.Services;
using LigaBetplay.Modules.Equipos;
using LigaBetplay.Modules.Partidos;
using LigaBetplay.Modules.Tabla;
using LigaBetplay.Modules.Estadisticas;

namespace LigaBetplay.Core
{
    // Fachada Central (Singleton) para acceder a toda la logica del torneo sin instanciar archivos manualmente.
    // Cumple con la peticion de "no usar metodos estaticos" en la logica, pero provee un punto de acceso unico.
    public class TorneoApp
    {
        private static TorneoApp? _instance;
        public static TorneoApp Instance => _instance ??= new TorneoApp();

        // Propiedades de solo lectura para acceder a los servicios
        public TorneoContext Contexto { get; }
        public ServicioEquipos Equipos { get; }
        public ServicioPartidos Partidos { get; }
        public ServicioTabla Tabla { get; }
        public ServicioEstadisticas Estadisticas { get; }
        public ServicioCalendario Calendario { get; }

        private TorneoApp()
        {
            // 1. Inicializar el estado central
            Contexto = new TorneoContext();
            
            // 2. Inicializar servicios base
            var servicioRandom = new ServicioRandom();
            Calendario = new ServicioCalendario();
            
            // 3. Inicializar servicios de negocio
            Equipos = new ServicioEquipos(Contexto);
            Partidos = new ServicioPartidos(Contexto, servicioRandom);
            Tabla = new ServicioTabla(Contexto);
            Estadisticas = new ServicioEstadisticas(Contexto);

            // 4. Cargar equipos iniciales y generar fixture
            InicializarLiga();
        }

        // Metodo para cargar los datos por primera vez
        private void InicializarLiga()
        {
            foreach (var equipo in Core.Data.DatosIniciales.ObtenerEquipos())
            {
                // Registramos directamente en la lista para evitar mensajes de consola innecesarios al arrancar
                Contexto.Equipos.Add(new Models.Equipo(equipo.Nombre));
            }

            if (Contexto.Equipos.Count > 0)
            {
                Contexto.Fixture = Calendario.GenerarFixture(Contexto.Equipos);
            }
        }

        // Metodo para borrar todo y volver a empezar
        public void ReiniciarTorneo()
        {
            Contexto.Equipos.Clear();
            Contexto.Partidos.Clear();
            Contexto.Fixture.Clear();
            Contexto.FechaActual = 1;
            InicializarLiga();
            Console.WriteLine("\n  La liga ha sido reiniciada completamente.");
        }
        
        // Atajo para regenerar el fixture
        public void RegenerarFixture()
        {
            if (Contexto.FechaActual == 1)
            {
                Contexto.Fixture = Calendario.GenerarFixture(Contexto.Equipos);
            }
        }
    }
}
