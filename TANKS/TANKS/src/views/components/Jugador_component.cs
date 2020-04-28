using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TANKS.src.views.components
{
    public partial class Jugador_component : UserControl
    {
        private Bitmap[] _imagenes = new Bitmap[]{
            global::TANKS.Properties.Resources.tanque___Jugador___izquierda,
            global::TANKS.Properties.Resources.tanque___Jugador,
            global::TANKS.Properties.Resources.tanque___Jugador___derecha,
            global::TANKS.Properties.Resources.tanque___Jugador___abajo,
            
        };
        public int Vida { get; set; }
        public Jugador_component()
        {
            InitializeComponent();
            Vida = progressBar1.Value;
        }

        public void girar(int direccion){
            this.pictureBox1.Image = _imagenes[direccion];
        }

        public void vida(int menos)
        {
            try
            {
                if (progressBar1.Value > progressBar1.Minimum)
                {
                    this.Vida -= menos;
                    this.progressBar1.Value -= menos;
                }
            }
            catch
            {
                this.Vida = 0;
                this.progressBar1.Value = 0;

            }
        }

        public void establecerVida(int value)
        {
            this.Vida = value;
            this.progressBar1.Value = value;
        }

    }
}
