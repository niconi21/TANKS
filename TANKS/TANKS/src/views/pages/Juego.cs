using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TANKS.src.tools.objects;
using TANKS.src.views.components;

namespace TANKS.src.views.pages
{
    public partial class Juego : Form
    {
        private Jugador[] jugadores = new Jugador[]{
            new Jugador{
                IdJugador = 0,
                Usuario = "niconi",
                Clave = "niconi",
                esOponente = false
            },
            new Jugador{
                IdJugador = 1,
                Usuario = "pablo",
                Clave = "pablo",
                esOponente = true
            },
        };
        private Thread _hilo_bala_jugador;

        private Jugador _jugador;
        private Jugador _oponente;

        private char _letra = 'w';

        private delegate void del(Control c, int x, int y);

        public Juego()
        {
            InitializeComponent();
            this._jugador = jugadores[1];
        }

        private void del_borrar(Control c, int x = 0, int y = 0)
        {
            if (InvokeRequired)
            {
                del borrar = new del(del_borrar);
                Object[] parametros = new Object[] { c, x, y };
                Invoke(borrar, parametros);
            }
            else
            {
                c.Dispose();
            }
        }
        private void del_moverBala(Control c, int x, int y)
        {
            if (InvokeRequired)
            {
                del moverBala = new del(del_moverBala);
                Object[] parametros = new Object[] { c, x, y };
                Invoke(moverBala, parametros);
            }
            else
            {
                c.Location = new Point(x, y);
            }
        }

        private void Juego_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_jugador.esOponente)
            {
                moverTanque(this.jugador_component1, e.KeyChar);
            }
            else
            {
                moverTanque(this.jugador_component2, e.KeyChar);
            }
        }

        private void moverTanque(Jugador_component componente,  char letra)
        {
            var ubicacion = componente.Location;
            if (letra.ToString().ToLower().Equals("a"))
            {
                componente.Location = new Point(ubicacion.X - 5, ubicacion.Y);
                componente.girar(0);
                _letra = letra;
            }
            if (letra.ToString().ToLower().Equals("w"))
            {
                componente.Location = new Point(ubicacion.X, ubicacion.Y - 5);
                componente.girar(1);
                _letra = letra;
            }
            if (letra.ToString().ToLower().Equals("d"))
            {
                componente.Location = new Point(ubicacion.X + 5, ubicacion.Y);
                componente.girar(2);
                _letra = letra;
            }
            if (letra.ToString().ToLower().Equals("s"))
            {
                componente.Location = new Point(ubicacion.X, ubicacion.Y + 5);
                componente.girar(3);
                _letra = letra;
            }
            if (letra == ' ')
            {

                crearBala(new PictureBox(), ubicacion, _letra);
            }
            
        }

        private void crearBala(PictureBox bala, Point ubicacion,char letra)
        {
            bala.BackColor = Color.Red;
            switch(letra){
                case 'a':
                    bala.Location = new Point(ubicacion.X-15, ubicacion.Y + 20);
                    bala.Size = new Size(15, 10);
                    break;
                case 'w':
                    bala.Location = new Point(ubicacion.X + 20, ubicacion.Y-15);
                    bala.Size = new Size(10, 15);
                    break;
                case 'd':
                    bala.Location = new Point(ubicacion.X+40, ubicacion.Y + 20);
                    bala.Size = new Size(15, 10);
                    break;
                case 's':
                    bala.Location = new Point(ubicacion.X + 20, ubicacion.Y + 40);
                    bala.Size = new Size(10, 15);
                    break;
            }
            Object[] parametros = new Object[] { bala, letra };
            this.Controls.Add(bala);
            this._hilo_bala_jugador = new Thread(moverBala);
            this._hilo_bala_jugador.Start(parametros);
        }

        private void moverBala(object sender)
        {
            PictureBox bala = (sender as Object[])[0] as PictureBox;
            char letra = (sender as Object[])[1].ToString().ElementAt(0);

            while ((bala.Location.X > 0 && bala.Location.X < this.Width) && (bala.Location.Y > 0 && bala.Location.Y < this.Height))
            {
                switch(letra){
                    case 'a':
                        del_moverBala(bala, bala.Location.X - 5, bala.Location.Y);
                        break;
                    case 'w':
                        del_moverBala(bala, bala.Location.X, bala.Location.Y - 5);
                        break;
                    case 'd':
                        del_moverBala(bala, bala.Location.X + 5, bala.Location.Y);
                        break;
                    case 's':
                        del_moverBala(bala, bala.Location.X, bala.Location.Y + 5);
                        break;
                }
                Thread.Sleep(100);
            }
            del_borrar(bala);
        }
    }
}
