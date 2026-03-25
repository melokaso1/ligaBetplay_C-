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
            if (equipos.Count < 2) return fixture;

            var circulo = new List<Equipo>(equipos);
            Equipo fantasma = new Equipo("FANTASMA");
            
            if (circulo.Count % 2 != 0)
            {
                circulo.Add(fantasma);
            }

            int n = circulo.Count; 

            for (int ronda = 0; ronda < n - 1; ronda++) 
            {
                var fecha = new Fecha(ronda + 1);

                for (int i = 0; i < n / 2; i++) 
                {
                    Equipo local, visitante;

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

                    if (local.Nombre != "FANTASMA" && visitante.Nombre != "FANTASMA")
                    {
                        int partidoIndex = fecha.Partidos.Count;
                        int dia = partidoIndex % 3 + 1;

                        fecha.Partidos.Add(new Partido(local, visitante, ronda + 1, dia));
                    }
                }

                fixture.Add(fecha);

                var ultimo = circulo[n - 1];
                circulo.RemoveAt(n - 1);
                circulo.Insert(1, ultimo);
            }

            return fixture;
        }
    }
}
