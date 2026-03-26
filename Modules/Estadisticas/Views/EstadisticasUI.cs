using System;
using LigaBetplay.Core;

namespace LigaBetplay.Modules.Estadisticas
{
    public class EstadisticasUI
    {
        public static void MostrarEstadisticas()
        {
            TorneoApp.Instance.Estadisticas.MostrarEstadisticas();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
