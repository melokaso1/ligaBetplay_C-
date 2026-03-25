using System;
using System.Collections.Generic;
using System.Linq;
using LigaBetplay.Core.Data;
using LigaBetplay.Core.Models;
using LigaBetplay.Core.Services;

namespace LigaBetplay.Modules.Partidos
{
    // Servicio responsable de simular partidos y fechas del torneo
    public class ServicioPartidos
    {
        private readonly TorneoContext _contexto;
        private readonly ServicioRandom _servicioRandom;

        public ServicioPartidos(TorneoContext contexto, ServicioRandom servicioRandom)
        {
            _contexto = contexto;
            _servicioRandom = servicioRandom;
        }

        // Simula todos los partidos de una fecha especifica y actualiza estadisticas
        public void SimularFecha(int numeroFecha)
        {
            var fecha = ObtenerFecha(numeroFecha);
            if (fecha == null)
            {
                Console.WriteLine($"La fecha {numeroFecha} no existe en el fixture.");
                return;
            }
            if (fecha.Simulada)
            {
                Console.WriteLine($"La fecha {numeroFecha} ya fue simulada.");
                return;
            }

            Console.WriteLine($"\n=== FECHA {numeroFecha} ===");

            // Simular goles y actualizar estadisticas para todos los partidos
            foreach (var partido in fecha.Partidos)
            {
                partido.GolesLocal = _servicioRandom.NextGoles();
                partido.GolesVisitante = _servicioRandom.NextGoles();
                ActualizarEstadisticas(partido);
                _contexto.Partidos.Add(partido);
            }

            // Mostrar resultados agrupados por dia (3-4-3)
            var porDia = fecha.Partidos.GroupBy(p => p.Dia).OrderBy(g => g.Key);
            foreach (var grupo in porDia)
            {
                Console.WriteLine($"\n  [ Dia {grupo.Key} ]");
                foreach (var partido in grupo)
                    Console.WriteLine($"    {partido.EquipoLocal.Nombre,-28} {partido.GolesLocal} - {partido.GolesVisitante,1}  {partido.EquipoVisitante.Nombre}");
            }

            fecha.Simulada = true;
        }

        // Simula la proxima fecha pendiente y avanza el puntero de FechaActual
        public void SimularFechaActual()
        {
            if (!HayFechasPendientes())
            {
                Console.WriteLine("Todas las fechas del torneo han sido simuladas.");
                return;
            }
            SimularFecha(_contexto.FechaActual);
            _contexto.FechaActual++;
        }

        // Indica si quedan fechas por simular
        public bool HayFechasPendientes()
        {
            return _contexto.FechaActual <= 19;
        }

        // Devuelve el numero de la proxima fecha a simular
        public int ObtenerNumeroFechaActual()
        {
            return _contexto.FechaActual;
        }

        // Devuelve una fecha especifica del fixture por su numero, o null si no existe
        public Fecha? ObtenerFecha(int numero)
        {
            return _contexto.Fixture.Find(f => f.Numero == numero);
        }

        // Devuelve el historial de partidos simulados
        public List<Partido> ListarPartidos()
        {
            return _contexto.Partidos;
        }

        // Actualiza PJ, PG, PE, PP, GF, GC de ambos equipos segun el resultado
        private void ActualizarEstadisticas(Partido partido)
        {
            var local = partido.EquipoLocal;
            var visitante = partido.EquipoVisitante;

            local.PJ++;
            visitante.PJ++;

            local.GF += partido.GolesLocal;
            local.GC += partido.GolesVisitante;
            visitante.GF += partido.GolesVisitante;
            visitante.GC += partido.GolesLocal;

            if (partido.GolesLocal > partido.GolesVisitante)
            {
                local.PG++;
                visitante.PP++;
            }
            else if (partido.GolesVisitante > partido.GolesLocal)
            {
                visitante.PG++;
                local.PP++;
            }
            else
            {
                local.PE++;
                visitante.PE++;
            }
        }
    }
}

