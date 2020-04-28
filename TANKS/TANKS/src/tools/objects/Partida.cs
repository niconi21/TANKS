using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKS.src.tools.objects
{
    public class Partida
    {
        public int Id { get; set; }
        public String Jugador { get; set; }
        public String Contricante { get; set; }

        public override string ToString()
        {
            return "id : " + Id +
                "\njugador : " + Jugador +
                "\nContricante : " + Contricante;
        }
    }
}
