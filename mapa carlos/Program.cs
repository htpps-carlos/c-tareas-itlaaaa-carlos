using Mapa_conceptual;
using System;
using System.Collections.Generic;

namespace Mapa_conceptual
{ 
    class Program
    {
        static void Main(string[] args)
        {
            List<MiembroDeLaComunidad> comunidad = new List<MiembroDeLaComunidad>
            {
                new Estudiante("Andrés"),
                new ExAlumno("Camila"),
                new Empleado("Roberto"),
                new Administrativo("Valentina"),
                new Docente("Héctor"),
                new Maestro("Lucía"),
                new Administrador("Sebastián")
            };

            Console.WriteLine("=== Información de la Comunidad Educativa ===\n");

            foreach (var persona in comunidad)
            {
                persona.MostrarInformacion();
            }
        }
    }
}
