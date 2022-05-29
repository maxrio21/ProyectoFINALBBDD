using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Globalization;

namespace Cajero
{
    internal class SQLUtilitiesClass
    {

        public NpgsqlConnection getConnection() 
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=ProyectoBDD;User Id=postgres;Password=admin");

                Console.WriteLine("Conexion establecida");

                return conn;
            }
            catch
            {
                Console.WriteLine("La conexión ha fallado.");
            }

            return null;
        }

        public String getPassword(String idTarjeta)
        {
            NpgsqlConnection con = this.getConnection();

            con.Open();

            if (idTarjeta == "")
            {
                return null;
            }

            NpgsqlCommand com = new NpgsqlCommand("SELECT contraseña FROM tarjeta WHERE id_tarjeta =" + idTarjeta + ";", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                //Console.WriteLine("{0}", reader[0]);
                return reader.GetInt32(0).ToString();
            }
            con.Close();
            return null;
        }

        public String getIbanPorCuenta(String idCuenta)
        {
            NpgsqlConnection con = this.getConnection();
            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT iban FROM cuenta_bancaria WHERE id_cuenta = " + idCuenta + ";", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                return reader.GetString(0);
            }
            con.Close();
            return null;
        }

        public String getCuentaPorIban(String IBAN)
        {
            NpgsqlConnection con = this.getConnection();
            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT obtenerCuentaPorIban('" + IBAN + "');", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                return reader.GetString(0);
            }
            con.Close();
            return null;
        }

        public String getCuenta(String idTarjeta)
        {

            NpgsqlConnection con = this.getConnection();
            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT obtenerCuenta("+ idTarjeta + ");",con);
            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                return reader.GetInt32(0).ToString();
            }
            con.Close();
            return null;
        }

        public String getTitular(String idCuenta)
        {
            NpgsqlConnection con = this.getConnection();
            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT obtenerTitular(" + idCuenta + ")", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                return reader.GetString(0);
            }
            con.Close();
            return null;
        }

        public String getEntidadB(String idCuenta)
        {

            NpgsqlConnection con = this.getConnection();
            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT obtenerEntidad(" + idCuenta + ")", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                return reader.GetString(0);
            }
            con.Close();
            return null;
        }

        public NpgsqlDataReader ultimosMovimientos(String idCuenta)
        {
            NpgsqlConnection con = this.getConnection();
            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT id_emisor AS EMISOR,id_receptor AS RECEPTOR,cantidad AS CANTIDAD,fecha AS FECHA,tipo AS TIPO FROM realizar_operacion WHERE id_emisor = " + idCuenta +"  ORDER BY fecha DESC LIMIT 10", con);
            NpgsqlDataReader reader = com.ExecuteReader();
            return reader;
        }
        public String obtenerSaldo(String idCuenta)
        {
            NpgsqlConnection con = this.getConnection();
            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT deposito FROM cuenta_bancaria WHERE id_cuenta = " + idCuenta + ";", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                return reader.GetDecimal(0).ToString();
            }
            con.Close();
            return null;
        }

        public void realizarOperacion(String id_emisor, String id_receptor, Double cantidad, int tipo)
        {
            NpgsqlConnection con = this.getConnection();
            con.Open();
            String dinero = cantidad.ToString().Replace(",", ".");
            Console.WriteLine(cantidad);
            NpgsqlCommand com;
            try
            {
                switch (tipo)
                {
                   
                    case 0:
                        com = new NpgsqlCommand("INSERT INTO realizar_operacion(id_emisor,id_receptor,cantidad,fecha,tipo) VALUES(" + id_emisor + "," + id_receptor + "," + ("-" + dinero) + ",TO_CHAR(NOW(),'YYYY-MM-DD HH24:MI:SS')::TIMESTAMP,'RETIRADA')", con);
                        com.ExecuteNonQuery();

                        break;
                    case 1:
                        com = new NpgsqlCommand("INSERT INTO realizar_operacion(id_emisor,id_receptor,cantidad,fecha,tipo) VALUES(" + id_emisor + "," + id_receptor + "," + dinero + ",TO_CHAR(NOW(),'YYYY-MM-DD HH24:MI:SS')::TIMESTAMP,'INGRESO')", con);
                        com.ExecuteNonQuery();
                        break;
                    case 2:
                        com = new NpgsqlCommand("INSERT INTO realizar_operacion(id_emisor,id_receptor,cantidad,fecha,tipo) VALUES(" + id_emisor + "," + id_receptor + "," + dinero + ",TO_CHAR(NOW(),'YYYY-MM-DD HH24:MI:SS')::TIMESTAMP,'TRANSFERENCIA')", con);
                        com.ExecuteNonQuery();
                        break;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
    }
}
