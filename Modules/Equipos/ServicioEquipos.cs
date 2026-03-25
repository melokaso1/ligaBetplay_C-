using System;
using System.Collections.Generic;
using System.Linq;
using LigaBetplay.Core.Data;
using LigaBetplay.Core.Models;

namespace LigaBetplay.Modules.Equipos
{
    // Servicio responsable de la logica de equipos del torneo
    public class ServicioEquipos
    {
        // Referencia al contexto central compartido
        private readonly TorneoContext _contexto;

        public ServicioEquipos(TorneoContext contexto)
        {
            _contexto = contexto;
        }

        // Crea un equipo nuevo con estadisticas en cero y lo agrega a la lista
        public void RegistrarEquipo(string nombre)
        {
            // Validar duplicado sin distinguir mayusculas
            bool yaExiste = _contexto.Equipos
                .Any(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (yaExiste)
            {
                Console.WriteLine($"El equipo '{nombre}' ya esta registrado.");
                return;
            }

            _contexto.Equipos.Add(new Equipo(nombre));
            Console.WriteLine($"Equipo '{nombre}' registrado.");
        }

        // Devuelve la lista completa de equipos registrados
        public List<Equipo> ListarEquipos()
        {
            return _contexto.Equipos;
        }
    }
}
