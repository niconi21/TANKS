using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TANKS.src.tools.database;
using TANKS.src.tools.objects;

namespace TANKS.src.views.pages
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jugador jugador = new Jugador
            {
                Usuario = txt_usuario.Text,
                Clave = txt_clave.Text,
                Nombre = txt_nombre.Text,
                Apepat = txt_apepat.Text,
                Apemat = txt_apemat.Text,
                Nivel = 0
            };
            (new Conexion()).registrarJugador(jugador);
            Login login = new Login();
            login.Show();
            this.Dispose();
        }
    }
}
