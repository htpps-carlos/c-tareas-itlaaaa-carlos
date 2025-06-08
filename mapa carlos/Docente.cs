using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa_conceptual
{
    public class Docente : Empleado
    {
        public Docente(string nombre) : base(nombre) { }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Docente: {Nombre}");
        }
    }
}
