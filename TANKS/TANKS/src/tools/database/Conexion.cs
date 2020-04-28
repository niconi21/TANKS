using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TANKS.src.tools.objects;
using System.Windows.Forms;

namespace TANKS.src.tools.database
{
    class Conexion
    {
        private String _StringConnection = "datasource=192.168.1.72;port=3306;username=niconi;password=root;database=tanks;";
        private MySqlConnection _conexion;
        public Conexion()
        {
            _conexion = new MySqlConnection(_StringConnection);
        }

        public Partida insertarPartidaJugador(Jugador jugador)
        {
            String insert = "INSERT INTO Partida (jugador) VALUES ('" + jugador.Usuario + "')";

            MySqlCommand insertCommand = new MySqlCommand(insert, _conexion);
            _conexion.Open();
            insertCommand.ExecuteNonQuery();
            _conexion.Close();

            String select = "SELECT * FROM Partida WHERE jugador = '" + jugador.Usuario + "' AND contricante is NULL LIMIT 1";
            _conexion.Open();
            MySqlCommand selectCommand = new MySqlCommand(select, _conexion);
            MySqlDataReader reader = selectCommand.ExecuteReader();
            Partida partida = null;
            if (reader.HasRows)
            {
                reader.Read();
                partida = new Partida
                {
                    Id = reader.GetInt32(0),
                    Jugador = reader.GetString(1)
                };
            }
            _conexion.Close();
            return partida;
        }

        public Partida insertarPartidaContricante(Jugador jugador)
        {
            String update = "UPDATE Partida SET contricante= '" + jugador.Usuario + "' WHERE contricante IS NULL LIMMIT 1";

            MySqlCommand updateCommand = new MySqlCommand(update, _conexion);
            _conexion.Open();
            updateCommand.ExecuteNonQuery();
            _conexion.Close();

            String select = "SELECT * FROM Partida WHERE contricante = '" + jugador.Usuario + "' AND ganador is NULL LIMIT 1";
            _conexion.Open();
            MySqlCommand selectCommand = new MySqlCommand(select, _conexion);
            MySqlDataReader reader = selectCommand.ExecuteReader();
            Partida partida = null;
            if (reader.HasRows)
            {
                reader.Read();
                partida = new Partida
                {
                    Id = reader.GetInt32(0),
                    Jugador = reader.GetString(1),
                    Contricante = reader.GetString(2)
                };
            }
            _conexion.Close();
            return partida;
        }

        public Movimiento CrearMovimiento(Partida partida, Jugador jugador)
        {
            String insert = "INSERT INTO Movimiento (partida, jugador) VALUES (" + partida.Id + ", '" + jugador.Usuario + "')";
            MySqlCommand insertCommand = new MySqlCommand(insert, _conexion);
            _conexion.Open();
            insertCommand.ExecuteNonQuery();
            _conexion.Close();

            String select = "SELECT * FROM Movimiento WHERE partida = " + partida.Id;
            MySqlCommand selectCommand = new MySqlCommand(select, _conexion);
            _conexion.Open();
            MySqlDataReader reader = selectCommand.ExecuteReader();
                Movimiento movimiento = null;
            if (reader.HasRows)
            {
                reader.Read();
                movimiento = new Movimiento
                {
                    Id = reader.GetInt32(0),
                    Partida = reader.GetInt32(1),
                    Jugador = reader.GetString(2),
                    X = reader.GetInt32(3),
                    Y = reader.GetInt32(4),
                    direccion = reader.GetChar(5),
                    bala = reader.GetBoolean(6)
                };
            }
            _conexion.Close();
            return movimiento;
        }

        public void actualizarMovimiento(Movimiento movimiento)
        {
            String update = "UPDATE Movimiento SET " +
                                "x = " + movimiento.X + ", "+
                                "y = " + movimiento.Y + ", " +
                                "direccion = '" + movimiento.direccion + "', " +
                                "bala = " + movimiento.bala + ", " +
                                "vida = " + movimiento.Vida + " " +
                                "WHERE id = " + movimiento.Id;
            MySqlCommand updateCommand = new MySqlCommand(update, _conexion);
            _conexion.Open();
            updateCommand.ExecuteNonQuery();
            _conexion.Close();
        }

        public void leerMovimientos(Movimiento movimiento)
        {
            String select = "SELECT x, y, direccion, bala, vida FROM Movimiento WHERE id = " + movimiento.Id;
            MySqlCommand selectCommand = new MySqlCommand(select, _conexion);
            _conexion.Open();
            MySqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                movimiento.X = reader.GetInt32(0);
                movimiento.Y = reader.GetInt32(1);
                movimiento.direccion = reader.GetChar(2);
                movimiento.bala = reader.GetBoolean(3);
                movimiento.Vida = reader.GetInt32(4);
            }
            
            _conexion.Close();
        }

        public void agregarBala(Movimiento movimiento)
        {
            String update = "UPDATE Movimiento set bala = " + movimiento.bala + " where id = " + movimiento.Id;
            MySqlCommand updateCommand = new MySqlCommand(update, _conexion);
            _conexion.Open();
            updateCommand.ExecuteNonQuery();
            _conexion.Close();
        }

    }
}
