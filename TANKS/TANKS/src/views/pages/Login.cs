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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usuario = txt_usuario.Text;
            String clave = txt_clave.Text;
            Jugador jugador = (new Conexion()).login(usuario, clave);
            if (jugador != null)
            {
                Inicio inicio = new Inicio(jugador);
                inicio.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecto");
            }

        }
    }
}
