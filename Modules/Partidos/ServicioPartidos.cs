using System;
using System.Collections.Generic;
using LigaBetplay.Core.Data;
using LigaBetplay.Core.Models;
using LigaBetplay.Core.Services;

namespace LigaBetplay.Modules.Partidos
{
    // Servicio responsable de simular y registrar partidos del torneo
    public class ServicioPartidos
    {
        private readonly TorneoContext _contexto;
        private readonly ServicioRandom _servicioRandom;

        public ServicioPartidos(TorneoContext contexto, ServicioRandom servicioRandom)
        {
            _contexto = contexto;
            _servicioRandom = servicioRandom;
        }

        // Simula un partido entre dos equipos, actualiza estadisticas y guarda el resultado
        public void SimularPartido(Equipo equipoLocal, Equipo equipoVisitante)
        {
            int golesLocal = _servicioRandom.NextGoles();
            int golesVisitante = _servicioRandom.NextGoles();

            // Actualizar partidos jugados
            equipoLocal.PJ++;
            equipoVisitante.PJ++;

            // Actualizar goles
            equipoLocal.GF += golesLocal;
            equipoLocal.GC += golesVisitante;
            equipoVisitante.GF += golesVisitante;
            equipoVisitante.GC += golesLocal;

            // Determinar resultado y actualizar victorias, empates y derrotas
            if (golesLocal > golesVisitante)
            {
                equipoLocal.PG++;
                equipoVisitante.PP++;
            }
            else if (golesVisitante > golesLocal)
            {
                equipoVisitante.PG++;
                equipoLocal.PP++;
            }
            else
            {
                equipoLocal.PE++;
                equipoVisitante.PE++;
            }

            // Guardar el partido en memoria
            var partido = new Partido(equipoLocal, equipoVisitante, golesLocal, golesVisitante);
            _contexto.Partidos.Add(partido);

            // Mostrar resultado en consola
            Console.WriteLine($"{equipoLocal.Nombre} {golesLocal} - {golesVisitante} {equipoVisitante.Nombre}");
        }

        // Devuelve el historial de partidos jugados
        public List<Partido> ListarPartidos()
        {
            return _contexto.Partidos;
        }
    }
}
