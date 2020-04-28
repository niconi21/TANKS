using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKS.src.tools.objects
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int Partida { get; set; }
        public String Jugador { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char direccion { get; set; }
        public bool bala { get; set; }
        public int Vida { get; set; }
        public override string ToString()
        {
            return "id : " + Id +
                "\npartida: " + Partida +
                "\njugador : " + Jugador +
                "\nX : " + X +
                "\nY : " + Y+
                "\ndireccion : " + direccion +
                "\nBala : " + bala +
                "\nVida : " + Vida ;
        }
    }
}
