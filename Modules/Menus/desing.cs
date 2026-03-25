using ligabetplay.Modules.Menus_logic;

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
            { "5", () => Environment.Exit(0) },
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
5. Salir

Oprime el numero que quieras seleccionar..."
            );

            Logic.Menus_logic(Selections);
        }
    }

    public static void teams_manaments()
    {
        Dictionary<string, Action> Selections = new Dictionary<string, Action>
        {
            { "3", MainMenu },
        };

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
3. Volver

Oprime el numero que quieras seleccionar..."
        );
        Logic.Menus_logic(Selections);
    }

    public static void sim_matches()
    {
        Console.Clear();
        Console.Write(
            @"
      _                 _           _                  _                         _   _     _           
  ___(_)_ __ ___  _   _| | __ _  __| | ___  _ __    __| | ___   _ __   __ _ _ __| |_(_) __| | ___  ___ 
 / __| | '_ ` _ \| | | | |/ _` |/ _` |/ _ \| '__|  / _` |/ _ \ | '_ \ / _` | '__| __| |/ _` |/ _ \/ __|
 \__ \ | | | | | | |_| | | (_| | (_| | (_) | |    | (_| |  __/ | |_) | (_| | |  | |_| | (_| | (_) \__ \
 |___/_|_| |_| |_|\__,_|_|\__,_|\__,_|\___/|_|     \__,_|\___| | .__/ \__,_|_|   \__|_|\__,_|\___/|___/
                                                               |_|                                     


"
        );
    }

    public static void show_pos_table()
    {
        Console.Clear();
        Console.WriteLine(
            @"
  _____     _     _             _                        _      _                       
 |_   _|_ _| |__ | | __ _    __| | ___   _ __   ___  ___(_) ___(_) ___  _ __   ___  ___ 
   | |/ _` | '_ \| |/ _` |  / _` |/ _ \ | '_ \ / _ \/ __| |/ __| |/ _ \| '_ \ / _ \/ __|
   | | (_| | |_) | | (_| | | (_| |  __/ | |_) | (_) \__ \ | (__| | (_) | | | |  __/\__ \
   |_|\__,_|_.__/|_|\__,_|  \__,_|\___| | .__/ \___/|___/_|\___|_|\___/|_| |_|\___||___/
                                        |_|                                             


"
        );
    }

    public static void show_stats()
    {
        Console.Clear();
        Console.WriteLine(
            @"
  _____     _            _ _     _   _               
 | ____|___| |_ __ _  __| (_)___| |_(_) ___ __ _ ___ 
 |  _| / __| __/ _` |/ _` | / __| __| |/ __/ _` / __|
 | |___\__ \ || (_| | (_| | \__ \ |_| | (_| (_| \__ \
 |_____|___/\__\__,_|\__,_|_|___/\__|_|\___\__,_|___/
                                                     


"
        );
    }
}
