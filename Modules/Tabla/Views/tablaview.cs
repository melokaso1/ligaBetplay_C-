using System;
using LigaBetplay.Modules.Tabla;

namespace ligabetplay.Modules.Tabla.Views;

public class Tablaview
{
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
}
