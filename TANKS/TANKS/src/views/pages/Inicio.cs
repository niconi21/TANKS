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
using TANKS.src.views.options;

namespace TANKS.src.views.pages
{
    public partial class Inicio : Form
    {
        private Jugador _jugador;
        private Oprion_inicio _inicio;
        public Inicio(Jugador jugador)
        {
            InitializeComponent();
            this._jugador = jugador;
            _inicio = new Oprion_inicio(_jugador);
            insertarContenido(_inicio);
        }

        private void Animacion_menu_entrar(object sender, EventArgs e)
        {
            Control panel = sender as Control;
            panel.BackColor = Color.FromArgb(66, 181, 115);
        }
        private void Animacion_menu_salir(object sender, EventArgs e)
        {
            Control panel = sender as Control;
            if (!panel.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                panel.BackColor = Color.FromArgb(13, 142, 68);
            }
        }

        private void insertarContenido(Control c)
        {
            this.panel_contenido.Controls.Clear();
            c.Dock = DockStyle.Fill;
            this.panel_contenido.Controls.Add(c);
        }

        private void panel_inicio_Click(object sender, EventArgs e)
        {
            _inicio.pararParpadeo();
            _inicio = new Oprion_inicio(_jugador);
            insertarContenido(_inicio);
        }

        private void Inicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _inicio.pararParpadeo();
                this.label6.Visible = true;
                this._inicio.SendToBack();
                Thread.Sleep(1000);
                Partida partida = (new Conexion()).insertarJugadorPartida(_jugador);
                Juego juego = new Juego(_jugador, partida);
                juego.Show();
                this.Dispose();
            }
        }

        private void panel_creditos_Click(object sender, EventArgs e)
        {
            this._inicio.pararParpadeo();
            Creditos_option creditos=new Creditos_option();
            insertarContenido(creditos);
        }

        private void panel_estadistica_Click(object sender, EventArgs e)
        {
            this._inicio.pararParpadeo();
            Estadistica_option estadisticas = new Estadistica_option(_jugador);
            insertarContenido(estadisticas);
        }

        private void panel_score_Click(object sender, EventArgs e)
        {
            this._inicio.pararParpadeo();
            Score_option score= new Score_option(_jugador);
            insertarContenido(score);
        }
    }
}
