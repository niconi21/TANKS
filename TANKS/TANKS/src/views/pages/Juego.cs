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
using TANKS.src.tools.database;
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
        private Thread _hilo_jugador;
        private Thread _hilo_contricante;

        private Jugador _jugador;
        private Jugador _oponente;
        private Partida _partida;
        private Movimiento _movimientoJugador;
        private Movimiento _movimientoOponente;

        private char _letra = 'w';
        private int _vidaJugador = 100;
        private int _vidaOponente = 100;

        private delegate void del(Control c, int x, int y);

        public Juego()
        {
            InitializeComponent();
            this._jugador = jugadores[0];
            _partida = new Partida
            {
                Id = 10,
                Jugador = "niconi",
                Contricante = "pablo"
            };

            _movimientoJugador = new Movimiento
            {
                Id = 2,
                Jugador = "niconi",
                X = 100,
                Y = 100,
                Vida = 100,
            };
            _movimientoOponente = new Movimiento
            {
                Id = 1,
                Jugador = "pablo",
                X = 100,
                Y = 100,
                Vida = 100,
            };

            if (!_jugador.esOponente)
            {
                MessageBox.Show("Jugador");
                this._hilo_jugador = new Thread(DatosJugador);
                this._hilo_jugador.Start();
            }
            else
            {
                MessageBox.Show("Oponente");
                this._hilo_contricante = new Thread(DatosContricante);
                this._hilo_contricante.Start();
            }
        }

        private void DatosContricante(object obj)
        {
            datos(jugador_component2,jugador_component1, _movimientoOponente, _movimientoJugador);
        }

        private void DatosJugador(object obj)
        {
            datos(jugador_component1,jugador_component2, _movimientoJugador, _movimientoOponente);
        }

        private void datos(Jugador_component componente, Jugador_component componente2, Movimiento movimiento, Movimiento movimiento2)
        {
            while (_vidaJugador > 0 && _vidaOponente > 0)
            {
                movimiento.X = componente.Location.X;
                movimiento.Y = componente.Location.Y;
                movimiento.direccion = this._letra;
                movimiento.Vida = this._vidaJugador;
                (new Conexion()).actualizarMovimiento(movimiento);

                (new Conexion()).leerMovimientos(movimiento2);
                del_movimientoRemoto(componente2);

            }
        }

        private void del_movimientoRemoto(Control c, int x = 0, int y = 0)
        {
            if (InvokeRequired)
            {
                del mover = new del(del_movimientoRemoto);
                Object[] parametros = new Object[] { c, x, y };
                Invoke(mover, parametros);
            }
            else
            {
                Jugador_component componente = c as Jugador_component;
                Movimiento m = _jugador.esOponente ? _movimientoJugador : _movimientoOponente;
                componente.Location = new Point(m.X, m.Y);
                switch (m.direccion)
                {
                    case 'a':
                        componente.girar(0);
                        break;
                    case 'w':
                        componente.girar(1);
                        break;
                    case 'd':
                        componente.girar(2);
                        break;
                    case 's':
                        componente.girar(3);
                        break;
                }
                componente.establecerVida(m.Vida);
                if (m.bala)
                {
                    crearBala(new PictureBox(), new Point(m.X,m.Y), m.direccion, !_jugador.esOponente);
                }
            }
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
        private void del_quitarVida(Control c, int x = 0, int y = 0)
        {
            if (InvokeRequired)
            {
                del vida = new del(del_quitarVida);
                Object[] parametros = new Object[] { c, x, y };
                Invoke(vida, parametros);
            }
            else
            {
                Jugador_component componente = c as Jugador_component;
                componente.vida(5);
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
        private void moverTanque(Jugador_component componente, char letra)
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
                Movimiento m = !_jugador.esOponente ? _movimientoJugador : _movimientoOponente;
                m.bala = true;
                (new Conexion()).agregarBala(m);
                crearBala(new PictureBox(), ubicacion, _letra, _jugador.esOponente);
                m.bala = false;
                (new Conexion()).agregarBala(m);
            }

        }
        private void crearBala(PictureBox bala, Point ubicacion, char letra, bool pertenece)
        {
            bala.BackColor = Color.Red;
            switch (letra)
            {
                case 'a':
                    bala.Location = new Point(ubicacion.X - 15, ubicacion.Y + 20);
                    bala.Size = new Size(15, 10);
                    break;
                case 'w':
                    bala.Location = new Point(ubicacion.X + 20, ubicacion.Y - 15);
                    bala.Size = new Size(10, 15);
                    break;
                case 'd':
                    bala.Location = new Point(ubicacion.X + 40, ubicacion.Y + 20);
                    bala.Size = new Size(15, 10);
                    break;
                case 's':
                    bala.Location = new Point(ubicacion.X + 20, ubicacion.Y + 40);
                    bala.Size = new Size(10, 15);
                    break;
            }
            Object[] parametros = new Object[] { bala, letra , pertenece};
            this.Controls.Add(bala);
            this._hilo_bala_jugador = new Thread(moverBala);
            this._hilo_bala_jugador.Start(parametros);
        }
        private void moverBala(object sender)
        {
            PictureBox bala = (sender as Object[])[0] as PictureBox;
            char letra = (sender as Object[])[1].ToString().ElementAt(0);
            bool pertenece = bool.Parse((sender as Object[])[2].ToString());
            while ((bala.Location.X > 0 && bala.Location.X < this.Width) && (bala.Location.Y > 0 && bala.Location.Y < this.Height))
            {
                switch (letra)
                {
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
                if (!pertenece)
                {
                    if (this.jugador_component2.Bounds.Contains(bala.Location))
                    {
                        del_quitarVida(jugador_component2);
                        this._vidaOponente = this.jugador_component2.Vida;
                        del_borrar(bala);
                        _movimientoJugador.Vida = _vidaOponente;
                        break;
                    }
                }
                else
                {
                    if (this.jugador_component1.Bounds.Contains(bala.Location))
                    {
                        del_quitarVida(jugador_component1);
                        this._vidaJugador= this.jugador_component1.Vida;
                        del_borrar(bala);
                        _movimientoOponente.Vida = _vidaJugador;
                        break;
                    }
                }
                Thread.Sleep(100);
            }
            del_borrar(bala);
        }
    }
}
