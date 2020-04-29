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

        public Jugador login(String usuario, String clave)
        {
            String select = "Select * from Jugador WHERE usuario = '" + usuario + "' AND clave = '" + clave + "'";
            MySqlCommand selectCommand = new MySqlCommand(select, _conexion);
            _conexion.Open();
            MySqlDataReader reader = selectCommand.ExecuteReader();
            Jugador jugador = null;
            if (reader.HasRows)
            {
                reader.Read();
                jugador = new Jugador
                {
                    IdJugador = reader.GetInt32(0),
                    Usuario = reader.GetString(1),
                    Clave = reader.GetString(2),
                    Nombre = reader.GetString(3),
                    Apepat = reader.GetString(4),
                    Apemat = reader.GetString(5),
                    Nivel = reader.GetInt32(6)
                };
            }
            _conexion.Close();
            return jugador;
        }
        public void registrarJugador(Jugador jugador)
        {
            String insert = "INSERT INTO Jugador (usuario, clave, nombre, apepat, apemat, nivel) VALUES ('" + jugador.Usuario + "','" + jugador.Clave + "','" + jugador.Nombre + "','" + jugador.Apepat + "','" + jugador.Apemat + "', "+jugador.Nivel+")";
            MySqlCommand insertCommand = new MySqlCommand(insert, _conexion);
            _conexion.Open();
            insertCommand.ExecuteNonQuery();
            _conexion.Close();
        }
        public void insertarEstadistica(Estadistica estadistica, Partida partida)
        {
            String insert = "INSERT INTO Estadistica (jugador,disparos,vida,tiempo) values (" +
                "'" + estadistica.Jugador + "'," + estadistica.Disparos + "," + estadistica.Vida + "," + estadistica.Tiempo + ")";
            MySqlCommand insertCommand = new MySqlCommand(insert, _conexion);
            _conexion.Open();
            insertCommand.ExecuteNonQuery();
            _conexion.Close();

            String update = "UPDATE Partida SET ganador = '" + partida.Ganador + "' WHERE id = " + partida.Id;
            MySqlCommand updateCommand = new MySqlCommand(update, _conexion);
            _conexion.Open();
            updateCommand.ExecuteNonQuery();
            _conexion.Close();
        }
        public Partida insertarJugadorPartida(Jugador jugador)
        {
            String select = "SELECT * FROM Partida WHERE contricante IS NULL LIMIT 1";
            MySqlCommand selectCommand = new MySqlCommand(select, _conexion);
            _conexion.Open();
            var reader = selectCommand.ExecuteReader();
            Partida partida = null;
            if (reader.HasRows)
            {
                reader.Read();
                partida = new Partida()
                {
                    Id = reader.GetInt32(0),
                    Jugador = reader.GetString(1),
                    Contricante = jugador.Usuario
                };
                jugador.esOponente = true;
                reader.Close();
                _conexion.Close();
                String update = "UPDATE Partida set contricante = '" + jugador.Usuario + "' WHERE id = " + partida.Id;
                MySqlCommand updateCommand = new MySqlCommand(update, _conexion);
                _conexion.Open();
                updateCommand.ExecuteNonQuery();
            }
            else
            {
                _conexion.Close();
                String insert = "Insert into Partida (jugador) values ('" + jugador.Usuario + "')";
                MySqlCommand insertCommand = new MySqlCommand(insert, _conexion);
                _conexion.Open();
                insertCommand.ExecuteNonQuery();
                jugador.esOponente = false;
                _conexion.Close();
                select = "SELECT * FROM Partida WHERE jugador = '"+jugador.Usuario+"' AND contricante IS NULL LIMIT 1";
                _conexion.Open();
                selectCommand = new MySqlCommand(select, _conexion);
                reader = selectCommand.ExecuteReader();
                
                if (reader.HasRows)
                {
                    reader.Read();
                    partida = new Partida()
                    {
                        Id = reader.GetInt32(0),
                        Jugador = reader.GetString(1)                        
                    };


                }
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

            String select = "SELECT * FROM Movimiento WHERE partida = " + partida.Id + " AND jugador = '"+jugador.Usuario+"'";
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
                };
            }
            _conexion.Close();
            return movimiento;
        }
        public Movimiento leerMovimientoEnemigo(Jugador jugador, Partida partida)
        {
            String select = "Select * FROM Movimiento WHERE partida = " + partida.Id + " AND jugador != '" + jugador.Usuario + "'";
            MySqlCommand selectCommand = new MySqlCommand(select, _conexion);
            _conexion.Open();
            var reader = selectCommand.ExecuteReader();
            Movimiento movimiento = null;
            if (reader.HasRows)
            {
                reader.Read();
                movimiento = new Movimiento
                {
                    Id = reader.GetInt32(0),
                    Partida = reader.GetInt32(1),
                    Jugador = reader.GetString(2)
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
            try
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
            }
            catch
            {

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
        public List<Estadistica> leerEstadisticas(Jugador jugador)
        {
            String select = "SELECT * FROM Estadistica WHERE jugador = '" + jugador.Usuario + "'";
            MySqlCommand selectCommand = new MySqlCommand(select, _conexion);
            _conexion.Open();
            var reader = selectCommand.ExecuteReader();
            List<Estadistica> estadisticas = new List<Estadistica>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    estadisticas.Add(new Estadistica
                    {
                        Id = reader.GetInt32(0),
                        Jugador = reader.GetString(1),
                        Disparos = reader.GetInt32(2),
                        Vida = reader.GetInt32(3),
                        Tiempo = reader.GetInt32(4)
                    });
                }
            }
            _conexion.Close();
            return estadisticas;
        }
        public List<Partida> leerPartida(Jugador jugador)
        {
            String select = "SELECT * FROM Partida WHERE jugador = '" + jugador.Usuario + "' OR contricante = '" + jugador.Usuario + "'";
            MySqlCommand selectCommand = new MySqlCommand(select, _conexion);
            _conexion.Open();
            var reader = selectCommand.ExecuteReader();
            List<Partida> partidas = new List<Partida>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    partidas.Add(new Partida
                    {
                        Id = reader.GetInt32(0),
                        Jugador = reader.GetString(1),
                        Contricante = reader.GetString(2),
                        Ganador = reader.GetString(3),
                    });
                }
            }
            _conexion.Close();
            return partidas;
        }
    }
}
