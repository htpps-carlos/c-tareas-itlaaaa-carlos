using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa_conceptual
{
    public class MiembroDeLaComunidad
    {
        public string Nombre { get; set; }

        public MiembroDeLaComunidad(string nombre)
        {
            Nombre = nombre;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Miembro de la Comunidad: {Nombre}");
        }
    }
} 