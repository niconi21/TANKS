using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKS.src.tools.objects
{
    public class Jugador
    {
        public int IdJugador { get; set; }
        public String Usuario { get; set; }
        public String Clave { get; set; }
        public String Nombre { get; set; }
        public String Apepat { get; set; }
        public String Apemat { get; set; }
        public bool esOponente { get; set; }
    }
}
