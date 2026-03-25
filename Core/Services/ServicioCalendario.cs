using System.Collections.Generic;
using LigaBetplay.Core.Models;

namespace LigaBetplay.Core.Services
{
    // Genera el calendario round-robin completo de 19 fechas para 20 equipos
    public class ServicioCalendario
    {
        // Algoritmo round-robin: fija el primer equipo y rota los 19 restantes
        public List<Fecha> GenerarFixture(List<Equipo> equipos)
        {
            var fixture = new List<Fecha>();
            var circulo = new List<Equipo>(equipos); // copia mutable para rotar
            int n = circulo.Count; // 20 equipos

            for (int ronda = 0; ronda < n - 1; ronda++) // 19 fechas
            {
                var fecha = new Fecha(ronda + 1);

                for (int i = 0; i < n / 2; i++) // 10 partidos por fecha
                {
                    Equipo local, visitante;

                    // Alternar local/visitante por paridad de ronda para equilibrar ventaja de campo
                    if (ronda % 2 == 0)
                    {
                        local = circulo[i];
                        visitante = circulo[n - 1 - i];
                    }
                    else
                    {
                        local = circulo[n - 1 - i];
                        visitante = circulo[i];
                    }

                    // Distribucion de partidos en 3 dias: Dia 1 (3 partidos), Dia 2 (4), Dia 3 (3)
                    int dia = i < 3 ? 1 : i < 7 ? 2 : 3;

                    fecha.Partidos.Add(new Partido(local, visitante, ronda + 1, dia));
                }

                fixture.Add(fecha);

                // Rotar: fijar circulo[0], mover el ultimo al indice 1
                var ultimo = circulo[n - 1];
                circulo.RemoveAt(n - 1);
                circulo.Insert(1, ultimo);
            }

            return fixture;
        }
    }
}
