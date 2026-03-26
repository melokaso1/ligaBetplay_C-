using System;
using LigaBetplay.Core;
using ligabetplay.Modules.Menus_logic;
using LigaBetplay.Modules.Partidos;

namespace ligabetplay.Modules.Partidos.Views;

public class MatchView
{
    public static void sim_matches()
    {
        bool inMenu = true;
        Dictionary<string, Action> Selections = new Dictionary<string, Action>
        {
            { "1", PartidosUI.SimularFecha },
            { "2", PartidosUI.VerHistorial },
            { "0", () => inMenu = false },
        };

        while (inMenu)
        {
            Console.Clear();
            Console.Write(
                @"

  ____  _                 _           _              ____         ____            _   _     _           
 / ___|(_)_ __ ___  _   _| | __ _  __| | ___  _ __  |  _ \  ___  |  _ \ __ _ _ __| |_(_) __| | ___  ___ 
 \___ \| | '_ ` _ \| | | | |/ _` |/ _` |/ _ \| '__| | | | |/ _ \ | |_) / _` | '__| __| |/ _` |/ _ \/ __|
  ___) | | | | | | | |_| | | (_| | (_| | (_) | |    | |_| |  __/ |  __/ (_| | |  | |_| | (_| | (_) \__ \
 |____/|_|_| |_| |_|\__,_|_|\__,_|\__,_|\___/|_|    |____/ \___| |_|   \__,_|_|   \__|_|\__,_|\___/|___/
                                                                                                        
"
            );

            int proxima = TorneoApp.Instance.Partidos.ObtenerNumeroFechaActual();
            int total = TorneoApp.Instance.Partidos.TotalFechas();

            if (TorneoApp.Instance.Partidos.HayFechasPendientes())
                Console.WriteLine($"\n  Proxima fecha a simular: Fecha {proxima} de {total}");
            else
                Console.WriteLine("\n  Todas las fechas han sido simuladas.");

            Console.WriteLine("\n  1. Simular siguiente fecha");
            Console.WriteLine("  2. Ver historial de partidos");
            Console.WriteLine("  0. Volver");
            Console.Write("\n  Oprime el numero que quieras seleccionar...");

            Logic.Menus_logic(Selections);
        }
    }
}
