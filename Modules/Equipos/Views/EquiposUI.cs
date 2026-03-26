using System;
using LigaBetplay.Core;

namespace LigaBetplay.Modules.Equipos
{
    public class EquiposUI
    {
        public static void RegistrarEquipo()
        {
            Console.Write("\nIngrese el nombre del equipo: ");
            string nombre = Console.ReadLine() ?? "";
            TorneoApp.Instance.Equipos.RegistrarEquipo(nombre);
            TorneoApp.Instance.RegenerarFixture();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void ListarEquipos()
        {
            Console.Clear();
            var equipos = TorneoApp.Instance.Equipos.ListarEquipos();
            Console.WriteLine("\n--- Equipos Registrados ---");
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
            }
            else
            {
                foreach (var e in equipos)
                {
                    Console.WriteLine($"- {e.Nombre}");
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void EliminarEquipo()
        {
            Console.Write("\nIngrese el nombre del equipo a eliminar: ");
            string nombre = Console.ReadLine() ?? "";
            TorneoApp.Instance.Equipos.EliminarEquipo(nombre);
            TorneoApp.Instance.RegenerarFixture();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
