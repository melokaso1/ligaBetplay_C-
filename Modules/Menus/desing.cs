using System;
using System.Collections.Generic;
using LigaBetplay.Core;
using ligabetplay.Modules.Menus_logic;
using LigaBetplay.Modules.Equipos;
using LigaBetplay.Modules.Partidos;
using LigaBetplay.Modules.Tabla;
using LigaBetplay.Modules.Estadisticas;

namespace ligabetplay.Modules.Menus;

public class Desing
{
    public static void MainMenu()
    {
        Dictionary<string, Action> Selections = new Dictionary<string, Action>
        {
            { "1", teams_manaments },
            { "2", sim_matches },
            { "3", show_pos_table },
            { "4", show_stats },
            { "5", () => TorneoApp.Instance.ReiniciarTorneo() },
            { "0", () => Environment.Exit(0) },
        };
        while (true)
        {
            Console.Clear();
            Console.Write(
                @"
 ___       ___  ________  ________                                                
|\  \     |\  \|\   ____\|\   __  \                                               
\ \  \    \ \  \ \  \___|\ \  \|\  \                                              
 \ \  \    \ \  \ \  \  __\ \   __  \                                             
  \ \  \____\ \  \ \  \|\  \ \  \ \  \                                            
   \ \_______\ \__\ \_______\ \__\ \__\                                           
    \|_______|\|__|\|_______|\|__|\|__|                                           
                                                                                  
                                                                                  
                                                                                  
 ________  _______  _________        ________  ___       ________      ___    ___ 
|\   __  \|\  ___ \|\___   ___\     |\   __  \|\  \     |\   __  \    |\  \  /  /|
\ \  \|\ /\ \   __/\|___ \  \_|     \ \  \|\  \ \  \    \ \  \|\  \   \ \  \/  / /
 \ \   __  \ \  \_|/__  \ \  \       \ \   ____\ \  \    \ \   __  \   \ \    / / 
  \ \  \|\  \ \  \_|\ \  \ \  \       \ \  \___|\ \  \____\ \  \ \  \   \/  /  /  
   \ \_______\ \_______\  \ \__\       \ \__\    \ \_______\ \__\ \__\__/  / /    
    \|_______|\|_______|   \|__|        \|__|     \|_______|\|__|\|__|\___/ /     
                                                                     \|___|/      
                                                                                  
                                                                                  
 
1. Gestionar Equipos
2. Simular Partidos
3. Ver Tabla De Posiciones
4. Ver estadisticas
5. Reiniciar Torneo
0. Salir

 Oprime el numero que quieras seleccionar..."
            );

            Logic.Menus_logic(Selections);
        }
    }

    public static void teams_manaments()
    {
        bool inMenu = true;
        Dictionary<string, Action> Selections = new Dictionary<string, Action>
        {
            { "1", EquiposUI.RegistrarEquipo },
            { "2", EquiposUI.ListarEquipos },
            { "3", EquiposUI.EliminarEquipo },
            { "0", () => inMenu = false },
        };

        while (inMenu)
        {
            Console.Clear();
            Console.Write(
                @"
   ____           _   _               _____            _                 
  / ___| ___  ___| |_(_) ___  _ __   | ____|__ _ _   _(_)_ __   ___  ___ 
 | |  _ / _ \/ __| __| |/ _ \| '_ \  |  _| / _` | | | | | '_ \ / _ \/ __|
 | |_| |  __/\__ \ |_| | (_) | | | | | |__| (_| | |_| | | |_) | (_) \__ \
  \____|\___||___/\__|_|\___/|_| |_| |_____\__, |\__,_|_| .__/ \___/|___/
                                              |_|       |_|              

1. Registrar equipo
2. Listar equipos
3. Eliminar equipo
0. Volver

Oprime el numero que quieras seleccionar..."
            );

            Logic.Menus_logic(Selections);
        }
    }

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

░██████╗██╗███╗░░░███╗██╗░░░██╗██╗░░░░░░█████╗░░█████╗░██╗░█████╗░███╗░░██╗
██╔════╝██║████╗░████║██║░░░██║██║░░░░░██╔══██╗██╔══██╗██║██╔══██╗████╗░██║
╚█████╗░██║██╔████╔██║██║░░░██║██║░░░░░███████║██║░░╚═╝██║██║░░██║██╔██╗██║
░╚═══██╗██║██║╚██╔╝██║██║░░░██║██║░░░░░██╔══██║██║░░██╗██║██║░░██║██║╚████║
██████╔╝██║██║░╚═╝░██║╚██████╔╝███████╗██║░░██║╚█████╔╝██║╚█████╔╝██║░╚███║
╚═════╝░╚═╝╚═╝░░░░░╚═╝░╚═════╝░╚══════╝╚═╝░░╚═╝░╚════╝░╚═╝░╚════╝░╚═╝░░╚══╝

██████╗░░█████╗░██████╗░████████╗██╗██████╗░░█████╗░░██████╗
██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██║██╔══██╗██╔══██╗██╔════╝
██████╔╝███████║██████╔╝░░░██║░░░██║██║░░██║██║░░██║╚█████╗░
██╔═══╝░██╔══██║██╔══██╗░░░██║░░░██║██║░░██║██║░░██║░╚═══██╗
██║░░░░░██║░░██║██║░░██║░░░██║░░░██║██████╔╝╚█████╔╝██████╔╝
╚═╝░░░░░╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝╚═════╝░░╚════╝░╚═════╝░
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

    public static void show_pos_table()
    {
        Console.Clear();
        Console.Write(
            @"
  _____     _     _             _                        _      _                       
 |_   _|_ _| |__ | | __ _    __| | ___   _ __   ___  ___(_) ___(_) ___  _ __   ___  ___ 
   | |/ _` | '_ \| |/ _` |  / _` |/ _ \ | '_ \ / _ \/ __| |/ __| |/ _ \| '_ \ / _ \/ __|
   | | (_| | |_) | | (_| | | (_| |  __/ | |_) | (_) \__ \ | (__| | (_) | | | |  __/\__ \
   |_|\__,_|_.__/|_|\__,_|  \__,_|\___| | .__/ \___/|___/_|\___|_|\___/|_| |_|\___||___/
                                        |_|                                             
"
        );
        TablaUI.MostrarTabla();
    }

    public static void show_stats()
    {
        Console.Clear();
        Console.Write(
            @"
  _____     _            _ _     _   _               
 | ____|___| |_ __ _  __| (_)___| |_(_) ___ __ _ ___ 
 |  _| / __| __/ _` |/ _` | / __| __| |/ __/ _` / __|
 | |___\__ \ || (_| | (_| | \__ \ |_| | (_| (_| \__ \
 |_____|___/\__\__,_|\__,_|_|___/\__|_|\___\__,_|___/
                                                     
"
        );
        EstadisticasUI.MostrarEstadisticas();
    }
}
