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
    public partial class Estadistica_option : UserControl
    {
        private Jugador _jugador;
        public Estadistica_option(Jugador jugador)
        {
            InitializeComponent();
            _jugador = jugador;
            texto();
            graficar();
        }

        private void graficar()
        {
            var estadisticas = (new Conexion()).leerEstadisticas(_jugador);
            int disparos = 0;
            int vida = 0;
            int tiempo = 0;
            foreach (var item in estadisticas)
            {
                disparos += item.Disparos;
                vida += item.Vida;
                tiempo += item.Tiempo;
            }
            chart1.Series[0].Points.AddY(disparos);
            chart1.Series[1].Points.AddY(vida);
            chart1.Series[2].Points.AddY(tiempo);
        }
        private void texto()
        {
            this.label_inicio.Text = "Estadisticas de " + _jugador.Nombre + " " + _jugador.Apepat + " " + _jugador.Apemat;
        }
    }
}
