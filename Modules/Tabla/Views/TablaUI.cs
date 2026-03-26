using System;
using LigaBetplay.Core;

namespace LigaBetplay.Modules.Tabla
{
    public class TablaUI
    {
        public static void MostrarTabla()
        {
            TorneoApp.Instance.Tabla.MostrarTabla();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
