using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TANKS.src.tools.objects;
using TANKS.src.tools.database;

namespace TANKS.src.views.options
{
    public partial class Score_option : UserControl
    {
        private Jugador _jugador;
        public Score_option(Jugador jugador)
        {
            InitializeComponent();
            _jugador = jugador;
            texto();
            tabla();
        }

        private void tabla()
        {

            var estadisticas = (new Conexion()).leerEstadisticas(_jugador);
            var partida = (new Conexion()).leerPartida(_jugador);

            tabla_estadisticas.DataSource = estadisticas;
            tabla_partida.DataSource = partida;
            tabla_partida.ForeColor = Color.Black;
            tabla_estadisticas.ForeColor = Color.Black;
        }
        private void texto()
        {
            this.label_inicio.Text = "Score de " + _jugador.Nombre + " " + _jugador.Apepat + " " + _jugador.Apemat;
        }
    }
}
