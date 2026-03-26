using System;
using System.Collections.Generic;
using System.Linq;
using LigaBetplay.Core.Data;
using LigaBetplay.Core.Models;

namespace LigaBetplay.Modules.Tabla
{
    // Servicio responsable de calcular y mostrar la tabla de posiciones global
    public class ServicioTabla
    {
        private readonly TorneoContext _contexto;

        public ServicioTabla(TorneoContext contexto)
        {
            _contexto = contexto;
        }

        // Devuelve los equipos ordenados por: TP desc, DG desc, GF desc, Nombre asc
        public List<Equipo> ObtenerTablaOrdenada()
        {
            return _contexto
                .Equipos.OrderByDescending(e => e.TP)
                .ThenByDescending(e => e.DG)
                .ThenByDescending(e => e.GF)
                .ThenBy(e => e.Nombre)
                .ToList();
        }

        // Imprime la tabla global en consola con posiciones del 1 al 20
        public void MostrarTabla()
        {
            var tabla = ObtenerTablaOrdenada();
            int fechasMostradas = _contexto.FechaActual - 1;
            int totalFechas = _contexto.Fixture.Count;

            Console.WriteLine();
            Console.WriteLine(
                $"  TABLA DE POSICIONES — Liga BetPlay 2026 (Fecha {fechasMostradas} de {totalFechas})"
            );
            Console.WriteLine(new string('-', 80));
            Console.WriteLine(
                $"  {"#", -4} {"Equipo", -28} {"PJ", 3} {"PG", 3} {"PE", 3} {"PP", 3} {"GF", 4} {"GC", 4} {"DG", 4} {"TP", 4}"
            );
            Console.WriteLine(new string('-', 80));

            for (int i = 0; i < tabla.Count; i++)
            {
                var e = tabla[i];
                Console.WriteLine(
                    $"  {i + 1, -4} {e.Nombre, -28} {e.PJ, 3} {e.PG, 3} {e.PE, 3} {e.PP, 3} {e.GF, 4} {e.GC, 4} {e.DG, 4} {e.TP, 4}"
                );
            }

            Console.WriteLine(new string('-', 80));
        }
    }
}
