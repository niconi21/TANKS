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
using System.Threading;

namespace TANKS.src.views.options
{
    public partial class Oprion_inicio : UserControl
    {
        private Jugador _jugador;
        private Thread _hilo;
        private delegate void del(bool parpadeo);
        public Oprion_inicio(Jugador jugador)
        {
            InitializeComponent();
            _jugador = jugador;
            texto();
            _hilo = new Thread(parpadeo);
            _hilo.Start();
        }

        private void del_parpadeo( bool bandera)
        {
            try
            {
                if (InvokeRequired)
                {
                    del parpadeo = new del(del_parpadeo);
                    Object[] parametros = new Object[] { bandera };
                    Invoke(parpadeo, parametros);
                }
                else
                    this.label1.Visible = bandera;
            }
            catch { }
        }
        private void parpadeo(object obj)
        {
            bool bandera = false;
            while (true)
            {
                Thread.Sleep(500);
                del_parpadeo(bandera);
                bandera = !bandera;
            }
        }
        private void texto()
        {
            this.label_inicio.Text = "Bienvenido " + _jugador.Nombre + " " + _jugador.Apepat + " " + _jugador.Apemat;
        }

        public void pararParpadeo()
        {
            this._hilo.Abort();
        }
    }
}
