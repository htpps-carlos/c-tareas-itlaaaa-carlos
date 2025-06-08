using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa_conceptual
{
    public class Empleado : MiembroDeLaComunidad
    {
        public Empleado(string nombre) : base(nombre) { }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Empleado: {Nombre}");
        }
    }
}